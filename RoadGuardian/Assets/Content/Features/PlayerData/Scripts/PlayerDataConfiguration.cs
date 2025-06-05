using UnityEngine;

namespace Content.Features.PlayerData.Scripts
{
    [CreateAssetMenu(menuName = "Configurations/Player/" + nameof(PlayerDataConfiguration), 
        fileName = nameof(PlayerDataConfiguration) + "_Default", order = 0)]
    public class PlayerDataConfiguration : ScriptableObject
    {
        [SerializeField] private PlayerData _playerData;
        
        public PlayerData GetPlayerData()
            => _playerData;
    }
}