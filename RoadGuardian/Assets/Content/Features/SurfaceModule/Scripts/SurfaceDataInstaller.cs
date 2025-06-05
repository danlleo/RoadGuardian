using Content.Global.Scripts;
using Core.AssetLoaderModule.Core.Scripts;
using Zenject;

namespace Content.Features.SurfaceModule.Scripts
{
    public class SurfaceDataInstaller : Installer<SurfaceDataInstaller>
    {
        public override void InstallBindings()
        {
            IAddressablesAssetLoaderService addressablesAssetLoaderService =
                Container.Resolve<IAddressablesAssetLoaderService>();
            
            Container.Bind<SurfaceDataConfiguration>().FromScriptableObject(
                addressablesAssetLoaderService.LoadAsset<SurfaceDataConfiguration>(Address.Configurations
                    .SurfaceDataConfiguration)).AsSingle();
            Container.Bind<ISurfaceDataService>().To<SurfaceDataService>().AsSingle();
        }
    }
}