using Content.Features.BulletModule.Scripts;
using Content.Features.CameraModule.Scripts;
using Content.Features.PlayerData.Scripts;
using Content.Features.PrefabSpawner.Scripts;
using Content.Features.TurretModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.GameBoostrapModule.Scripts.ProjectDI
{
    [CreateAssetMenu(menuName = "Configurations/GameBootstrap/" + nameof(GlobalSceneContextInstaller),
        fileName = nameof(GlobalSceneContextInstaller) + "_Default", order = 0)]
    public class GlobalSceneContextInstaller : ScriptableObjectInstaller<GlobalSceneContextInstaller>
    {
        public override void InstallBindings()
        {
            PrefabSpawnerInstaller.Install(Container);
            PlayerDataInstaller.Install(Container);
            BulletPoolInstaller.Install(Container);
            CameraInstaller.Install(Container);
            TurretDataInstaller.Install(Container);
        }
    }
}