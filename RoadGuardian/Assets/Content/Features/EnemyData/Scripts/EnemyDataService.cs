namespace Content.Features.EnemyData.Scripts
{
    public class EnemyDataService : IEnemyDataService
    {
        private readonly EnemyDataConfiguration _enemyDataConfiguration;

        public EnemyDataService(EnemyDataConfiguration enemyDataConfiguration) 
            => _enemyDataConfiguration = enemyDataConfiguration;

        public EnemyData GetEnemyData() 
            => _enemyDataConfiguration.GetEnemyData();
    }
}