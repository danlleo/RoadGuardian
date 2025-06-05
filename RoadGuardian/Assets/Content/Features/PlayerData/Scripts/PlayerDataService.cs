namespace Content.Features.PlayerData.Scripts
{
    public class PlayerDataService : IPlayerDataService
    {
        private readonly PlayerDataConfiguration _playerDataConfiguration;

        public PlayerDataService(PlayerDataConfiguration playerDataConfiguration) 
            => _playerDataConfiguration = playerDataConfiguration;
        
        public PlayerData GetPlayerData()
            => _playerDataConfiguration.GetPlayerData();
    }
}