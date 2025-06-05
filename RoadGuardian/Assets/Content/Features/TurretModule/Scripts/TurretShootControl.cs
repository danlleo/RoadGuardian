using System.Collections;
using Content.Features.BulletModule.Scripts;
using Content.Features.InteractionModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.TurretModule.Scripts
{
    [DisallowMultipleComponent]
    public class TurretShootControl : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;

        private InteractRaycastSystem _interactRaycastSystem;
        private TurretTransformModel _turretTransformModel;
        private BulletPool _bulletPool;
        private TurretData _turretData;
        private ITurretInput _turretInput;

        private Coroutine _shootingRoutine;

        [Inject]
        public void InjectDependencies(TurretTransformModel turretTransformModel, BulletPool bulletPool,
            TurretDataConfiguration turretDataConfiguration, ITurretInput turretInput)
        {
            _turretTransformModel = turretTransformModel;
            _bulletPool = bulletPool;
            _turretData = turretDataConfiguration.GetTurretData();
            _turretInput = turretInput;
        }
        
        public void StartShooting()
        {
            _turretInput.OnTurretDeltaUpdated += HandleTurretRotation;
            _shootingRoutine ??= StartCoroutine(ShootingRoutine());
        }

        public void StopShooting()
        {
            _turretInput.OnTurretDeltaUpdated -= HandleTurretRotation;
            
            if (_shootingRoutine != null)
                StopCoroutine(_shootingRoutine);
        }

        private IEnumerator ShootingRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_turretData.FireRate);
                Vector3 shootDirection = _turretTransformModel.TurretTransform.forward;
                Bullet bullet = _bulletPool.Spawn();
                bullet.Initialize(_shootPoint.position);
                bullet.Shoot(shootDirection);
            }
        }

        private void HandleTurretRotation(float deltaY) 
            => _turretTransformModel.RotateY(deltaY);
    }
}