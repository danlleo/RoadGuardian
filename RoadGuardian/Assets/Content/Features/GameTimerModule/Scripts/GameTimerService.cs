using System;
using System.Collections;
using Content.Features.LevelBuilderModule.Scripts;
using Content.Global.Scripts;
using UnityEngine;

namespace Content.Features.GameTimerModule.Scripts
{
    public class GameTimerService : IGameTimerService
    {
        public event Action OnTimerStarted;
        public event Action OnTimerStopped;
        public event Action<float> OnNormalizedTimerUpdated;
        public event Action OnTimerEnd;
        
        private readonly ICoroutineRunner _coroutineRunner;

        private readonly float _totalTime;
        private float _elapsedTime;
        
        public GameTimerService(LevelBuilderConfiguration levelBuilderConfiguration, ICoroutineRunner coroutineRunner)
        {
            _totalTime = levelBuilderConfiguration.GetLevelBuilderData().TotalLevelTimeDuration;
            _coroutineRunner = coroutineRunner;
        }
        
        public void RunTimer()
        {
            _coroutineRunner.StartCoroutine(RunTimerRoutine());
            OnTimerStarted?.Invoke();
        }

        public void StopTimer()
        {
            _coroutineRunner.StopCoroutine(RunTimerRoutine());
            OnTimerStopped?.Invoke();
        }

        private IEnumerator RunTimerRoutine()
        {
            _elapsedTime = 0f;
            
            while (_elapsedTime < _totalTime)
            {
                _elapsedTime += Time.deltaTime;
                float normalizedTime = Mathf.Clamp01(_elapsedTime / _totalTime);
                OnNormalizedTimerUpdated?.Invoke(normalizedTime);
                yield return null;
            }
            
            _elapsedTime = _totalTime;
            OnNormalizedTimerUpdated?.Invoke(1f);
            OnTimerEnd?.Invoke();
        }
    }
}