using UnityEngine;

namespace Content.Features.ObjectPoolModule.Scripts
{
    [CreateAssetMenu(menuName = "Configurations/PoolConfig/" + nameof(ObjectPoolConfiguration), 
        fileName = nameof(ObjectPoolConfiguration) + "_Default", order = 0)]
    public class ObjectPoolConfiguration : ScriptableObject
    {
        [SerializeField] private ObjectPoolData _objectPoolData;
        
        public ObjectPoolData GetObjectPoolData() 
            => _objectPoolData;
    }
}
