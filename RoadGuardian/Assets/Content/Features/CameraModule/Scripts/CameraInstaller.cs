using Zenject;

namespace Content.Features.CameraModule.Scripts
{
    public class CameraInstaller : Installer<CameraInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerCameraTransformModel>().AsSingle();
            Container.Bind<PlayerCameraModel>().AsSingle();
        }
    }
}