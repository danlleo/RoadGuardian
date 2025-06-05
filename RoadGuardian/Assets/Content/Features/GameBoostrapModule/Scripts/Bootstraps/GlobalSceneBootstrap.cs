using Content.Features.GameFlowStateMachineModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.GameBoostrapModule.Scripts.Bootstraps
{
    public class GlobalSceneBootstrap : MonoBehaviour
    {
        private GameFlowStateMachine _gameFlowStateMachine;
        
        [Inject]
        public void InjectDependencies(GameFlowStateMachine gameFlowStateMachine)
            => _gameFlowStateMachine = gameFlowStateMachine;

        private void Start() 
            => _gameFlowStateMachine.Enter<EnterMainFlowState>();
    }
}
