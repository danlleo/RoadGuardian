using Content.Features.DamageableModule.Scripts;

namespace Content.Features.PlayerData.Scripts
{
    public class PlayerHealthModel
    {
        private MonoDamageable _playerDamageable;
        
        public void InitializeHealth(MonoDamageable monoDamageable, float startHealth)
        {
            _playerDamageable = monoDamageable;
            monoDamageable.SetHealth(startHealth);
        }
        
        public MonoDamageable PlayerDamageable 
            => _playerDamageable;
    }
}