using UnityEngine;

namespace Content.Features.TurretModule.Scripts
{
    [CreateAssetMenu(menuName = "Configurations/Turret/" + nameof(TurretDataConfiguration), 
        fileName = nameof(TurretDataConfiguration) + "_Default", order = 0)]
    public class TurretDataConfiguration : ScriptableObject
    {
        [SerializeField] private TurretData _turretData;
        
        public TurretData GetTurretData()
            => _turretData;
    }
}