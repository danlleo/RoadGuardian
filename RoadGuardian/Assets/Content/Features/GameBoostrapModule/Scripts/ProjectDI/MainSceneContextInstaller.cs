using Content.Features.EnemyData.Scripts;
using Content.Features.GameFlowFacadeModule.Scripts;
using Content.Features.GameRunnerModule.Scripts;
using Content.Features.LevelBuilderModule.Scripts;
using Content.Features.SurfaceModule.Scripts;
using Content.Features.UIModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.GameBoostrapModule.Scripts.ProjectDI
{
    [CreateAssetMenu(menuName = "Configurations/GameBootstrap/" + nameof(MainSceneContextInstaller),
        fileName = nameof(MainSceneContextInstaller) + "_Default", order = 0)]
    public class MainSceneContextInstaller : ScriptableObjectInstaller<MainSceneContextInstaller>
    {
        public override void InstallBindings()
        {
            UIInstaller.Install(Container);
            EnemyDataInstaller.Install(Container);
            LevelBuilderDataInstaller.Install(Container);
            SurfaceDataInstaller.Install(Container);
            GameFlowFacadeInstaller.Install(Container);
            GameRunnerInstaller.Install(Container);
        }
    }
}
