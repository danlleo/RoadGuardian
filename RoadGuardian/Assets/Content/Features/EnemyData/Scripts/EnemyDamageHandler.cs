using Content.Features.DamageableModule.Scripts;
using Content.Features.PlayerData.Scripts;
using Content.Global.Scripts;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Content.Features.EnemyData.Scripts
{
    [DisallowMultipleComponent]
    public class EnemyDamageHandler : MonoBehaviour
    {
        private static readonly int s_emissionColor = Shader.PropertyToID("_EmissionColor");
        
        [SerializeField] private MonoDamageable _monoDamageable;
        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private ParticleSystem _hitParticleSystem;
        [SerializeField] private ParticleSystem _deathParticleSystem;
        
        private Material _enemyMaterial;
        private Transform _playerTransform;

        private readonly float _flashDuration = 0.15f;

        private readonly float _knockbackDistance = 1f;
        private readonly float _knockbackDuration = 0.1f;

        [Inject]
        public void InjectDependencies(PlayerTransformModel playerTransformModel) 
            => _playerTransform = playerTransformModel.PlayerTransform;

        private void Awake() 
            => _enemyMaterial = _skinnedMeshRenderer.material;

        private void Start()
        {
            _monoDamageable.OnDamaged += HandleTakenDamage;
            _monoDamageable.OnKilled += HandleDeath;
        }

        private void OnDestroy()
        {
            _monoDamageable.OnDamaged -= HandleTakenDamage;
            _monoDamageable.OnKilled -= HandleDeath;
        }

        private void HandleTakenDamage()
        {
            Knockback();
            Flash();
            _hitParticleSystem.Play();
        }

        private void Knockback()
        {
            Vector3 knockbackDirection = (transform.position - _playerTransform.position).normalized;
            transform.DOMove(transform.position + knockbackDirection * _knockbackDistance, _knockbackDuration)
                .SetEase(Ease.OutQuad);
        }

        private void Flash()
        {
            Color originalEmission = _enemyMaterial.GetColor(s_emissionColor);
            Color flashColor = Color.white;
            DOTween.Sequence()
                .Append(_enemyMaterial.DOColor(flashColor, s_emissionColor, _flashDuration))
                .Append(_enemyMaterial.DOColor(originalEmission, s_emissionColor, _flashDuration))
                .SetEase(Ease.InOutQuad);
        }
        
        private void HandleDeath()
        {
            if (_deathParticleSystem == null) return;
            _deathParticleSystem.transform.SetParent(null);
            _deathParticleSystem.Play();
            Destroy(gameObject);
        }
    }
}