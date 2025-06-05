using Content.Features.DamageableModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.PlayerData.Scripts
{
    [DisallowMultipleComponent]
    public class PlayerRegister : MonoBehaviour
    {
        private PlayerTransformModel _playerTransformModel;
        private PlayerHealthModel _playerHealthModel;
        private IPlayerDataService _playerDataService;

        [Inject]
        public void InjectDependencies(PlayerTransformModel playerTransformModel, PlayerHealthModel playerHealthModel,
            IPlayerDataService playerDataService)
        {
            _playerTransformModel = playerTransformModel;
            _playerHealthModel = playerHealthModel;
            _playerDataService = playerDataService;
        }

        private void Awake()
        {
            _playerTransformModel.PlayerTransform = transform;
            _playerHealthModel.InitializeHealth(GetComponent<MonoDamageable>(),
                _playerDataService.GetPlayerData().StartHealth);
        }
    }
}