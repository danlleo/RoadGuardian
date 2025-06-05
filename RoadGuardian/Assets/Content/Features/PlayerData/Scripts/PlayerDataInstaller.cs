using Content.Global.Scripts;
using Core.AssetLoaderModule.Core.Scripts;
using Zenject;

namespace Content.Features.PlayerData.Scripts
{
    public class PlayerDataInstaller : Installer<PlayerDataInstaller>
    {
        public override void InstallBindings()
        {
            IAddressablesAssetLoaderService addressablesAssetLoaderService =
                Container.Resolve<IAddressablesAssetLoaderService>();

            Container.Bind<PlayerDataConfiguration>().FromScriptableObject(
                addressablesAssetLoaderService.LoadAsset<PlayerDataConfiguration>(Address.Configurations
                    .PlayerDataConfiguration)).AsSingle();
            Container.Bind<IPlayerDataService>().To<PlayerDataService>().AsSingle();
            Container.Bind<PlayerTransformModel>().AsSingle();
            Container.Bind<PlayerHealthModel>().AsSingle();
        }
    }
}