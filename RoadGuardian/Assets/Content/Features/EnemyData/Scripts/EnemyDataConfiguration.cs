using UnityEngine;

namespace Content.Features.EnemyData.Scripts
{
    [CreateAssetMenu(menuName = "Configurations/Enemy/" + nameof(EnemyDataConfiguration), 
        fileName = nameof(EnemyDataConfiguration) + "_Default", order = 0)]
    public class EnemyDataConfiguration : ScriptableObject
    {
        [SerializeField] private EnemyData _enemyData;

        public EnemyData GetEnemyData()
            => _enemyData;
    }
}