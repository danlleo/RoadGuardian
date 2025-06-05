using Zenject;

namespace Content.Features.GameRunnerModule.Scripts
{
    public class GameRunnerInstaller : Installer<GameRunnerInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameRunnerService>().AsSingle().NonLazy();
        }
    }
}