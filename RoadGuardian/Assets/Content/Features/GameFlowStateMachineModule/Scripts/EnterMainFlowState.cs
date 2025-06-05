using System.Collections.Generic;
using Content.Global.Scripts;
using Core.SceneLoaderServiceModule.Scripts;

namespace Content.Features.GameFlowStateMachineModule.Scripts
{
    public class EnterMainFlowState : GameFlowStateBase
    {
        private readonly ISceneLoaderService _sceneLoaderService;

        public EnterMainFlowState(ISceneLoaderService sceneLoaderService) =>
            _sceneLoaderService = sceneLoaderService;
        
        public override void Enter()
        {
            List<string> enabledScenes = new() {
                SceneInBuild.GlobalScene,
                SceneInBuild.MainScene,
            };

            _sceneLoaderService.LoadScenesAsync(enabledScenes, SceneInBuild.MainScene, true);
        }

        public override void Exit() { }
    }
}