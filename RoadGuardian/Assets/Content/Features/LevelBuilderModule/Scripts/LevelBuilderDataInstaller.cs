using Content.Features.GameTimerModule.Scripts;
using Content.Global.Scripts;
using Core.AssetLoaderModule.Core.Scripts;
using Zenject;

namespace Content.Features.LevelBuilderModule.Scripts
{
    public class LevelBuilderDataInstaller : Installer<LevelBuilderDataInstaller>
    {
        public override void InstallBindings()
        {
            IAddressablesAssetLoaderService addressablesAssetLoaderService =
                Container.Resolve<IAddressablesAssetLoaderService>();

            Container.Bind<LevelBuilderConfiguration>().FromScriptableObject(
                addressablesAssetLoaderService.LoadAsset<LevelBuilderConfiguration>(Address.Configurations
                    .LevelBuilderConfiguration)).AsSingle();
            Container.Bind<ILevelBuilderDataService>().To<LevelBuilderDataService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelBuilder>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameTimerService>().AsSingle();
        }
    }
}