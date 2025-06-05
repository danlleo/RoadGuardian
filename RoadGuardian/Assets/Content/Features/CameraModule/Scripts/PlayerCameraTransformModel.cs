using System;
using UnityEngine;

namespace Content.Features.CameraModule.Scripts
{
    public class PlayerCameraTransformModel
    {
        public event Action<Transform> OnPlayerCameraTransformChanged;

        public Transform PlayerCameraTransform
        {
            get =>
                _playerCameraTransform;
            set
            {
                OnPlayerCameraTransformChanged?.Invoke(value);
                _playerCameraTransform = value;
            }
        }
        
        public Vector3 Position {
            get =>
                _playerCameraTransform.position;
            set {
                if (_playerCameraTransform != null)
                    _playerCameraTransform.position = value;
            }
        }
        
        public Quaternion Rotation {
            get =>
                _playerCameraTransform.rotation;
            set {
                if (_playerCameraTransform != null)
                    _playerCameraTransform.rotation = value;
            }
        }
        
        public Vector3 Scale {
            get =>
                _playerCameraTransform.localScale;
            set {
                if (_playerCameraTransform != null)
                    _playerCameraTransform.localScale = value;
            }
        }

        private Transform _playerCameraTransform;
    }
}