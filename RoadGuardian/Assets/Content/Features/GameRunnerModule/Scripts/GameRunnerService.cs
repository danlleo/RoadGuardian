using System;
using System.Collections;
using System.Collections.Generic;
using Content.Features.DamageableModule.Scripts;
using Content.Features.GameFlowFacadeModule.Scripts;
using Content.Features.GameTimerModule.Scripts;
using Content.Features.PlayerData.Scripts;
using Content.Features.UIModule.Scripts;
using Content.Global.Scripts;
using Core.InputModule.Scripts;
using Core.SceneLoaderServiceModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.GameRunnerModule.Scripts
{
    public class GameRunnerService : IInitializable, IDisposable, IGameRunnerService
    {
        public event Action OnGameWon;
        public event Action OnGameLost;
        
        private readonly IGameFlowFacadeService _gameFlowFacadeService;
        private readonly IInputListener _inputListener;
        private readonly IGameTimerService _gameTimerService;
        private readonly PlayerHealthModel _playerHealthModel;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IUIFactory _uiFactory;
        private readonly ISceneLoaderService _sceneLoaderService;
        
        private MonoDamageable _playerDamageable;
        private IntroductionWindow _introductionWindow;

        public GameRunnerService(IGameFlowFacadeService gameFlowFacadeService, IInputListener inputListener,
            IGameTimerService gameTimerService, PlayerHealthModel playerHealthModel, ICoroutineRunner coroutineRunner,
            IUIFactory uiFactory, ISceneLoaderService sceneLoaderService)
        {
            _gameFlowFacadeService = gameFlowFacadeService;
            _inputListener = inputListener;
            _gameTimerService = gameTimerService;
            _playerHealthModel = playerHealthModel;
            _coroutineRunner = coroutineRunner;
            _uiFactory = uiFactory;
            _sceneLoaderService = sceneLoaderService;
        }

        public void Initialize()
        {
            _uiFactory.CreateUIRoot();
            _introductionWindow = _uiFactory.CreateIntroductionWindow();
            _inputListener.OnInteractionStarted += HandleFirstInteract;
            _gameTimerService.OnTimerEnd += HandleFinishedTimer;
            _coroutineRunner.StartCoroutine(AwaitPlayerDamageableRoutine());
        }

        public void Dispose()
        {
            _inputListener.OnInteractionStarted -= HandleFirstInteract;
            _gameTimerService.OnTimerEnd -= HandleFinishedTimer;
            
            if (_playerDamageable != null)
                _playerDamageable.OnKilled -= HandlePlayerDeath;
        }

        /// <summary>
        /// I KNOW THIS IS HORRIBLE SOLUTION, BUT MY HEAD IS BOILING CURRENTLY
        /// </summary>
        /// <returns></returns>
        private IEnumerator AwaitPlayerDamageableRoutine()
        {
            yield return new WaitUntil(() => _playerHealthModel.PlayerDamageable != null);
            _playerDamageable = _playerHealthModel.PlayerDamageable;
            _playerDamageable.OnKilled += HandlePlayerDeath;
        }
        
        private void HandleFirstInteract(Vector2 _)
        {
            _introductionWindow.Hide();
            _uiFactory.CreateDistanceDisplay().Construct(_gameTimerService);;
            _uiFactory.CreatePlayerHealthBar();
            _inputListener.OnInteractionStarted -= HandleFirstInteract;
            _gameFlowFacadeService.StartGame();
        }
        
        private void HandleRestartGame(Vector2 _)
        {
            _inputListener.OnInteractionStarted -= HandleRestartGame;
            List<string> enabledScenes = new() {
                SceneInBuild.GlobalScene,
                SceneInBuild.MainScene,
            };

            _sceneLoaderService.UnloadScenesAsync(enabledScenes);
            _sceneLoaderService.LoadSceneAsync(SceneInBuild.BootstrapScene, true);
        }

        private void HandleFinishedTimer()
        {
            _uiFactory.CreateGameOutcomeWindow().Display(true);
            OnGameWon?.Invoke();
            _gameFlowFacadeService.EndGame();
            
            _gameTimerService.OnTimerEnd -= HandleFinishedTimer;
            
            if (_playerDamageable != null)
                _playerDamageable.OnKilled -= HandlePlayerDeath;
            
            _inputListener.OnInteractionStarted += HandleRestartGame;
        }

        private void HandlePlayerDeath()
        {
            _uiFactory.CreateGameOutcomeWindow().Display(false);
            OnGameLost?.Invoke();
            _gameFlowFacadeService.EndGame();
            
            _gameTimerService.OnTimerEnd -= HandleFinishedTimer;
            
            if (_playerDamageable != null)
                _playerDamageable.OnKilled -= HandlePlayerDeath;
                    
            _inputListener.OnInteractionStarted += HandleRestartGame;
        }
    }
}