using Content.Global.Scripts;
using Zenject;

namespace Content.Features.GameFlowStateMachineModule.Scripts
{
    public class GameFlowStateMachineInstaller : Installer<GameFlowStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromNewComponentOnNewGameObject().AsSingle()
                .NonLazy();
            Container.Bind<GameFlowStateMachine>().AsSingle();
            Container.Bind<GlobalGameFlowState>().AsSingle();
            Container.Bind<EnterMainFlowState>().AsSingle();
        }
    }
}