using System;

namespace Content.Features.DamageableModule.Scripts
{
    public interface IMonoDamageable
    {
        event Action OnDamaged;
        event Action OnKilled;
        event Action<float> OnHealthChanged;
        event Action<float> OnNormalizedHealthPercentChanged; 
        void Damage(float damage);
        void SetHealth(float health);
        void AddHealth(float health);
        float GetNormalizedHealthValue();
    }
}