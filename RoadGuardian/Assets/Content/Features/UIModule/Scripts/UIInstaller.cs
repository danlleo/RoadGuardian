using Zenject;

namespace Content.Features.UIModule.Scripts
{
    public class UIInstaller : Installer<UIInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle();
        }
    }
}