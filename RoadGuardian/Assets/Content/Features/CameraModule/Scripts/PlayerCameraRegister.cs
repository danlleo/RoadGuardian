using UnityEngine;
using Zenject;

namespace Content.Features.CameraModule.Scripts
{
    [DisallowMultipleComponent]
    public class PlayerCameraRegister : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private PlayerCameraModel _playerCameraModel;
        private PlayerCameraTransformModel _playerCameraTransformModel;

        [Inject]
        public void InjectDependencies(PlayerCameraModel playerCameraModel,
            PlayerCameraTransformModel playerCameraTransformModel)
        {
            _playerCameraModel = playerCameraModel;
            _playerCameraTransformModel = playerCameraTransformModel;
        }

        private void Awake()
        {
            _playerCameraTransformModel.PlayerCameraTransform = transform;
            _playerCameraModel.CurrentCamera = _camera;
        }
    }
}