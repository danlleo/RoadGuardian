using Content.Features.EnemyData.Scripts;
using Content.Features.PrefabSpawner.Scripts;
using Content.Features.SurfaceModule.Scripts;
using Content.Global.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.LevelBuilderModule.Scripts
{
    public class LevelBuilder : IInitializable
    {
        private readonly IPrefabsFactory _prefabsFactory;
        private readonly SurfaceDataConfiguration _surfaceDataConfiguration;
        private readonly IEnemyDataService _enemyDataService;
        private readonly EnemyHealthModel _enemyHealthModel;

        private readonly int _initialFreeSurfacesAmount;
        private readonly int _enemyFilledSurfacesAmount;
        private readonly float _placeOffset;

        private float _lastZPosition;

        private Transform _surfaceHolder;
            
        public LevelBuilder(IPrefabsFactory prefabsFactory, LevelBuilderConfiguration levelBuilderConfiguration,
            SurfaceDataConfiguration surfaceDataConfiguration, IEnemyDataService enemyDataService,
            EnemyHealthModel enemyHealthModel)
        {
            _prefabsFactory = prefabsFactory;
            _surfaceDataConfiguration = surfaceDataConfiguration;
            _initialFreeSurfacesAmount = levelBuilderConfiguration.GetLevelBuilderData().InitialFreeSurfacesAmount;
            _enemyFilledSurfacesAmount = levelBuilderConfiguration.GetLevelBuilderData().EnemyFilledSurfacesAmount;
            _placeOffset = levelBuilderConfiguration.GetLevelBuilderData().PlaceOffset;
            _enemyDataService = enemyDataService;
            _enemyHealthModel = enemyHealthModel;
        }

        public void Initialize()
        {
            CreateInitialSurfaces();
        }

        public void CreateLevel()
        {
            for (int i = 0; i < _enemyFilledSurfacesAmount; i++) 
                SpawnSurface(_lastZPosition + _placeOffset);
        }

        private void CreateInitialSurfaces()
        {
            _surfaceHolder = new GameObject("Surfaces").transform;
            
            for (int i = 0; i < _initialFreeSurfacesAmount; i++)
            {
                float zPosition = i * _placeOffset;
                SpawnSurface(zPosition, false);
            }
        }

        private void SpawnSurface(float zPosition, bool shouldSpawnEnemies = true)
        {
            Surface surface = _prefabsFactory.Create(Address.Prefabs.Surface, new Vector3(0f, 0f, zPosition))
                .GetComponent<Surface>();
            surface.Construct(_prefabsFactory, _surfaceDataConfiguration, _enemyDataService, _enemyHealthModel,
                shouldSpawnEnemies);
            surface.transform.SetParent(_surfaceHolder);
            _lastZPosition = zPosition;
        }
    }
}