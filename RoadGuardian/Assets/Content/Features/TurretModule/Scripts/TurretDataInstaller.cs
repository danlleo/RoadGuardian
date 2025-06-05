using Content.Global.Scripts;
using Core.AssetLoaderModule.Core.Scripts;
using Zenject;

namespace Content.Features.TurretModule.Scripts
{
    public class TurretDataInstaller : Installer<TurretDataInstaller>
    {
        public override void InstallBindings()
        {
            IAddressablesAssetLoaderService addressablesAssetLoaderService =
                Container.Resolve<IAddressablesAssetLoaderService>();

            Container.Bind<TurretDataConfiguration>().FromScriptableObject(
                addressablesAssetLoaderService.LoadAsset<TurretDataConfiguration>(Address.Configurations
                    .TurretDataConfiguration)).AsSingle();
            Container.Bind<TurretDataService>().AsSingle();
            Container.Bind<TurretTransformModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurretInput>().AsSingle();
        }
    }
}