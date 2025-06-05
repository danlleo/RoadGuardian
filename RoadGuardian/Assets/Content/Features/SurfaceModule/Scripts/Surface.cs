using System.Collections.Generic;
using Content.Features.EnemyData.Scripts;
using Content.Features.PrefabSpawner.Scripts;
using Content.Global.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.SurfaceModule.Scripts
{
    [DisallowMultipleComponent]
    public class Surface : MonoBehaviour
    {
        [SerializeField] private List<Transform> _enemiesSpawnPoints = new();
        
        private IPrefabsFactory _prefabsFactory;
        private IEnemyDataService _enemyDataService;
        private EnemyHealthModel _enemyHealthModel;
        
        private int _maxAmountOfProbableEnemies;
        private bool _shouldSpawnEnemies;

        public void Construct(IPrefabsFactory prefabsFactory, SurfaceDataConfiguration surfaceDataConfiguration,
            IEnemyDataService enemyDataService, EnemyHealthModel enemyHealthModel,
            bool shouldSpawnEnemies = true)
        {
            _prefabsFactory = prefabsFactory;
            _enemyDataService = enemyDataService;
            _enemyHealthModel = enemyHealthModel;
            _maxAmountOfProbableEnemies = surfaceDataConfiguration.GetSurfaceData().MaxAmountOfProbableEnemies;
            _shouldSpawnEnemies = shouldSpawnEnemies;
        }

        private void Start() 
            => SpawnEnemies();

        private void SpawnEnemies()
        {
            if (!_shouldSpawnEnemies) return;
            if (_enemiesSpawnPoints.Count == 0)
            {
                Debug.LogWarning("No spawn points assigned for enemies!");
                return;
            }

            int enemiesToSpawn = Mathf.Min(_maxAmountOfProbableEnemies, _enemiesSpawnPoints.Count);
            List<Transform> availableSpawnPoints = new(_enemiesSpawnPoints);
            
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                if (availableSpawnPoints.Count == 0)
                    break;

                int randomIndex = Random.Range(0, availableSpawnPoints.Count);
                Vector3 spawnPosition = availableSpawnPoints[randomIndex].position;
                
                availableSpawnPoints.RemoveAt(randomIndex);

                EnemyRegister enemyRegister = _prefabsFactory.Create(Address.Prefabs.Enemy, spawnPosition)
                    .GetComponent<EnemyRegister>();
                enemyRegister.transform.SetParent(transform);
                enemyRegister.Construct(_enemyDataService, _enemyHealthModel);
            }
        }
    }
}