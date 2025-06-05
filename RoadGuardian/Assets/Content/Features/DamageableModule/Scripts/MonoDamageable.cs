using System;
using UnityEngine;

namespace Content.Features.DamageableModule.Scripts
{
    [DisallowMultipleComponent]
    public class MonoDamageable : MonoBehaviour, IMonoDamageable
    {
        public event Action OnDamaged;
        public event Action OnKilled;
        public event Action<float> OnHealthChanged;
        public event Action<float> OnNormalizedHealthPercentChanged;

        // TEAM LEAD, I'M TRYING MY BEST TO THINK ABOUT EXTENSIBILITY, I USE SerializeField ONLY TO EXPOSE IT
        // TO SET THE HEALTH YOU HAVE TO DO THIS IN THE CONFIG
        [SerializeField] private float _health;

        private float _startHealth;
        
        public void Damage(float damage)
        {
            _health -= damage;
            _health = Mathf.Clamp(_health, 0f, _startHealth);
            
            OnDamaged?.Invoke();
            OnHealthChanged?.Invoke(_health);
            OnNormalizedHealthPercentChanged?.Invoke(_health / _startHealth);
            
            if (_health <= 0)
                OnKilled?.Invoke();
        }

        public void SetHealth(float health)
        {
            _startHealth = health;
            _health = health;

            OnHealthChanged?.Invoke(_health);
            OnNormalizedHealthPercentChanged?.Invoke(1f);
        }

        public void AddHealth(float health)
        {
            _health += health;
            _health = Mathf.Clamp(_health, 0, _startHealth);

            OnHealthChanged?.Invoke(_health);
            OnNormalizedHealthPercentChanged?.Invoke(_health / _startHealth);
        }
        
        public float GetNormalizedHealthValue()
        {
            return _health / _startHealth;
        }
    }
}
