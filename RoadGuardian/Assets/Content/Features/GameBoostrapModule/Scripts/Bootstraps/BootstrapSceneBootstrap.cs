using Content.Features.GameFlowStateMachineModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.GameBoostrapModule.Scripts.Bootstraps
{
    [DisallowMultipleComponent]
    public class BootstrapSceneBootstrap : MonoBehaviour
    {
        private GameFlowStateMachine _gameFlowStateMachine;
        
        [Inject]
        public void InjectDependencies(GameFlowStateMachine gameFlowStateMachine) 
            => _gameFlowStateMachine = gameFlowStateMachine;

        private void Start()
            => _gameFlowStateMachine.Enter<GlobalGameFlowState>();
    }
}
