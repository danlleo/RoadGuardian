using Cinemachine;
using Content.Features.PlayerData.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.CameraModule.Scripts
{
    [DisallowMultipleComponent]
    public class CinemachineCameraSetup : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _cinemachineCamera;
        
        private PlayerTransformModel _playerTransformModel;
        private PlayerCameraTransformModel _playerCameraTransformModel;

        [Inject]
        public void InjectDependencies(PlayerTransformModel playerTransformModel,
            PlayerCameraTransformModel playerCameraTransformModel)
        {
            _playerTransformModel = playerTransformModel;
            _playerCameraTransformModel = playerCameraTransformModel;
        }

        private void Start()
        {
            if (_playerTransformModel.PlayerTransform == null) return;
            SwitchTarget(_playerTransformModel.PlayerTransform);
            SetDefaultCameraValues();
        }
        
        private void OnEnable() =>
            _playerTransformModel.OnPlayerTransformChanged += SwitchTarget;

        private void OnDisable() =>
            _playerTransformModel.OnPlayerTransformChanged -= SwitchTarget;

        public void SetMoveCameraValues()
        {
            _playerCameraTransformModel.Rotation = Quaternion.Euler(45f, 0f, 0f);

            CinemachineFramingTransposer framingTransposer =
                _cinemachineCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            
            if (framingTransposer == null) return;
            framingTransposer.m_TrackedObjectOffset = new Vector3(0f, 10f, -4f);
        }
        
        private void SetDefaultCameraValues()
        {
            _playerCameraTransformModel.Rotation = Quaternion.Euler(45f, 45f, 0f);

            CinemachineFramingTransposer framingTransposer =
                _cinemachineCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            
            if (framingTransposer == null) return;
            framingTransposer.m_TrackedObjectOffset = new Vector3(0f, 3f, 0f);
        }

        private void SwitchTarget(Transform target) =>
            _cinemachineCamera.Follow = target;
    }
}