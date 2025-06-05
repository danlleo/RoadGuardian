using System.Collections;
using Content.Features.DamageableModule.Scripts;
using Content.Features.TurretModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.BulletModule.Scripts
{
    [DisallowMultipleComponent]
    public class Bullet : MonoBehaviour
    {
        [Header("External References")]
        [SerializeField] private TrailRenderer _trailRenderer;
        
        private float _damage;
        private float _speed;
        private float _disposeTime;
        
        private BulletPool _bulletPool;
        private TurretData _turretData;
        private Coroutine _moveBulletRoutine;

        [Inject]
        public void InjectDependencies(BulletPool bulletPool, TurretDataConfiguration turretDataConfiguration)
        {
            _bulletPool = bulletPool;
            _turretData = turretDataConfiguration.GetTurretData();
        }

        private void Awake()
        {
            _damage = _turretData.BulletDamage;
            _speed = _turretData.BulletSpeed;
            _disposeTime = _turretData.DisposeBulletTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IMonoDamageable monoDamageable)) return;
            monoDamageable.Damage(_damage);
            ReturnToPool();
        }
        
        public void Initialize(Vector3 position)
            => transform.position = position;

        public void Shoot(Vector3 direction)
        {
            Vector3 normalizedDirection = direction.normalized;
            _moveBulletRoutine = StartCoroutine(MoveBulletRoutine(normalizedDirection));
        }
        
        private IEnumerator MoveBulletRoutine(Vector3 direction)
        {
            float elapsedTime = 0f;
            while (elapsedTime < _disposeTime)
            {
                transform.position += direction * (_speed * Time.deltaTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
    
            ReturnToPool();
        }

        private void ReturnToPool()
        {
            StopCoroutine(_moveBulletRoutine);
            _trailRenderer.Clear();
            _bulletPool.Despawn(this);
        }

        public class Factory : PlaceholderFactory<Bullet> { }
    }
}