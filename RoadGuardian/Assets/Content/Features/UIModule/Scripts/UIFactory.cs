using Content.Features.PrefabSpawner.Scripts;
using Content.Global.Scripts;
using UnityEngine;

namespace Content.Features.UIModule.Scripts
{
    public class UIFactory : IUIFactory
    {
        private readonly IPrefabsFactory _prefabsFactory;

        private Transform _uiRootTransform;

        public UIFactory(IPrefabsFactory prefabsFactory) 
            => _prefabsFactory = prefabsFactory;

        public void CreateUIRoot()
            => _uiRootTransform = _prefabsFactory.Create(Address.Prefabs.UIRoot).transform;

        public IntroductionWindow CreateIntroductionWindow()
        {
            Transform introductionWindowTransform = _prefabsFactory.Create(Address.Prefabs.IntroductionWindow).transform;
            introductionWindowTransform.SetParent(_uiRootTransform, false);
            return introductionWindowTransform.GetComponent<IntroductionWindow>();
        }

        public DistanceWindow CreateDistanceDisplay()
        {
            Transform distanceWindowTransform = _prefabsFactory.Create(Address.Prefabs.DistanceWindow).transform;
            distanceWindowTransform.SetParent(_uiRootTransform, false);
            return distanceWindowTransform.GetComponent<DistanceWindow>();
        }

        public PlayerHealthBarWindow CreatePlayerHealthBar()
        {
            Transform playerHealthBarWindowTransform =
                _prefabsFactory.Create(Address.Prefabs.PlayerHealthBarWindow).transform;
            playerHealthBarWindowTransform.SetParent(_uiRootTransform, false);
            
            return playerHealthBarWindowTransform.GetComponent<PlayerHealthBarWindow>();
        }

        public GameOutcomeWindow CreateGameOutcomeWindow()
        {
            Transform gameOutcomeWindowTransform =
                _prefabsFactory.Create(Address.Prefabs.GameOutcomeWindow).transform;
            gameOutcomeWindowTransform.SetParent(_uiRootTransform, false);
            
            return gameOutcomeWindowTransform.GetComponent<GameOutcomeWindow>();
        }
    }
}