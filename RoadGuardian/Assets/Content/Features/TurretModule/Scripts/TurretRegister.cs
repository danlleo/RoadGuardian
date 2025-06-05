using UnityEngine;
using Zenject;

namespace Content.Features.TurretModule.Scripts
{
    [DisallowMultipleComponent]
    public class TurretRegister : MonoBehaviour
    {
        private TurretTransformModel _turretTransformModel;
        private TurretDataService _turretDataService;

        [Inject]
        public void InjectDependencies(TurretTransformModel turretTransformModel, TurretDataService turretDataService)
        {
            _turretTransformModel = turretTransformModel;
            _turretDataService = turretDataService;
        }
        
        private void Awake()
        {
            _turretTransformModel.TurretTransform = transform;
        }
    }
}