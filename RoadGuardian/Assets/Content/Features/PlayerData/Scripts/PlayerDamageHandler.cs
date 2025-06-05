using Content.Features.DamageableModule.Scripts;
using UnityEngine;

namespace Content.Features.PlayerData.Scripts
{
    [DisallowMultipleComponent]
    public class PlayerDamageHandler : MonoBehaviour
    {
        [SerializeField] private MonoDamageable _monoDamageable;
        [SerializeField] private ParticleSystem _deathParticleSystem;
        
        private void Start()
        {
            _monoDamageable.OnKilled += HandlePlayerDeath;
        }

        private void OnDestroy()
        {
            _monoDamageable.OnKilled -= HandlePlayerDeath;
        }

        private void HandlePlayerDeath()
        {
            _monoDamageable.OnKilled -= HandlePlayerDeath;
            gameObject.SetActive(false);
            _deathParticleSystem.transform.SetParent(null);
            _deathParticleSystem.Play();
        }
    }
}