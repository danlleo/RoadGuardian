using Content.Features.DamageableModule.Scripts;

namespace Content.Features.EnemyData.Scripts
{
    public class EnemyHealthModel
    {
        public void InitializeHealth(MonoDamageable monoDamageable, float startHealth)
        {
            _enemyDamagaeble = monoDamageable;
            monoDamageable.SetHealth(startHealth);
        }

        public MonoDamageable EnemyDamagaeble => _enemyDamagaeble;

        private MonoDamageable _enemyDamagaeble;
    }
}