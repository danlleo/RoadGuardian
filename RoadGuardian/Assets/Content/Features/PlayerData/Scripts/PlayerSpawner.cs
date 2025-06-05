using Content.Features.PrefabSpawner.Scripts;
using Content.Global.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.PlayerData.Scripts
{
    [DisallowMultipleComponent]
    public class PlayerSpawner : MonoBehaviour
    {
        private IPrefabsFactory _prefabsFactory;

        [Inject]
        public void InjectDependencies(IPrefabsFactory prefabsFactory) 
            => _prefabsFactory = prefabsFactory;

        private void Awake()
        {
            GameObject playerPrefab = _prefabsFactory.Create(Address.Prefabs.Player, transform.position);
            playerPrefab.transform.position = transform.position;
            _prefabsFactory.Create(Address.Prefabs.PlayerCamera);
        }
    }
}
