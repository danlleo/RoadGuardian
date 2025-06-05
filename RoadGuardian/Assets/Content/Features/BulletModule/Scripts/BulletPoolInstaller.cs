using Content.Global.Scripts;
using Core.AssetLoaderModule.Core.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.BulletModule.Scripts
{
    public class BulletPoolInstaller : Installer<BulletPoolInstaller>
    {
        private const string TransformGroupName = "Bullets";

        public override void InstallBindings()
        {
            IAddressablesAssetLoaderService addressablesAssetLoaderService =
                Container.Resolve<IAddressablesAssetLoaderService>();

            GameObject bulletPrefab = addressablesAssetLoaderService.LoadAsset<GameObject>(Address.Prefabs.Bullet);

            Container.BindMemoryPool<Bullet, BulletPool>()
                .WithInitialSize(100)
                .FromComponentInNewPrefab(bulletPrefab)
                .UnderTransformGroup(TransformGroupName);
        }
    }
}