using System;
using UnityEngine;

namespace Content.Features.PlayerData.Scripts
{
    public class PlayerTransformModel
    {
        public event Action<Transform> OnPlayerTransformChanged;

        public Transform PlayerTransform
        {
            get =>
                _playerTransform;
            set
            {
                OnPlayerTransformChanged?.Invoke(value);
                _playerTransform = value;
            }
        }
        
        public Vector3 Position {
            get =>
                _playerTransform.position;
            set {
                if (_playerTransform != null)
                    _playerTransform.position = value;
            }
        }
        
        public Quaternion Rotation {
            get =>
                _playerTransform.rotation;
            set {
                if (_playerTransform != null)
                    _playerTransform.rotation = value;
            }
        }
        
        public Vector3 Scale {
            get =>
                _playerTransform.localScale;
            set {
                if (_playerTransform != null)
                    _playerTransform.localScale = value;
            }
        }

        private Transform _playerTransform;
    }
}