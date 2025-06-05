using Content.Global.Scripts;
using Core.AssetLoaderModule.Core.Scripts;
using Zenject;

namespace Content.Features.EnemyData.Scripts
{
    public class EnemyDataInstaller : Installer<EnemyDataInstaller>
    {
        public override void InstallBindings()
        {
            IAddressablesAssetLoaderService addressablesAssetLoaderService =
                Container.Resolve<IAddressablesAssetLoaderService>();
            
            Container.Bind<EnemyDataConfiguration>().FromScriptableObject(
                addressablesAssetLoaderService.LoadAsset<EnemyDataConfiguration>(Address.Configurations
                    .EnemyDataConfiguration)).AsSingle();
            Container.Bind<IEnemyDataService>().To<EnemyDataService>().AsSingle();
            Container.Bind<EnemyHealthModel>().AsSingle();
        }
    }
}