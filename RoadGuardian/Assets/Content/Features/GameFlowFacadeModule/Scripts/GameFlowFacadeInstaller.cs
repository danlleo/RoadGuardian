using Zenject;

namespace Content.Features.GameFlowFacadeModule.Scripts
{
    public class GameFlowFacadeInstaller : Installer<GameFlowFacadeInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameFlowFacadeService>().AsSingle().NonLazy();
        }
    }
}