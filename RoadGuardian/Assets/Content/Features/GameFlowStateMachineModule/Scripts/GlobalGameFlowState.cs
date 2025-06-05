using Content.Global.Scripts;
using Core.SceneLoaderServiceModule.Scripts;

namespace Content.Features.GameFlowStateMachineModule.Scripts
{
    public class GlobalGameFlowState : GameFlowStateBase
    {
        private readonly ISceneLoaderService _sceneLoaderService;

        public GlobalGameFlowState(ISceneLoaderService sceneLoaderService) 
            => _sceneLoaderService = sceneLoaderService;

        public override void Enter() 
            => _sceneLoaderService.LoadSceneAsync(SceneInBuild.GlobalScene, true);

        public override void Exit() { }
    }
}