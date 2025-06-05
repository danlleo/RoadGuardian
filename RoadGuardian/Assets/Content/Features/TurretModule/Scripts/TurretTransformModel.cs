using System;
using UnityEngine;

namespace Content.Features.TurretModule.Scripts
{
    public class TurretTransformModel
    {
        public event Action<Transform> OnTurretTransformChanged;
        public float CurrentYRotation { get; private set; }
        
        public Transform TurretTransform
        {
            get =>
                _turretTransform;
            set
            {
                OnTurretTransformChanged?.Invoke(value);
                _turretTransform = value;
            }
        }

        public Vector3 Position {
            get =>
                _turretTransform.position;
            set {
                if (_turretTransform != null)
                    _turretTransform.position = value;
            }
        }

        public Quaternion Rotation {
            get =>
                _turretTransform.rotation;
            set {
                if (_turretTransform != null)
                    _turretTransform.rotation = value;
            }
        }

        public Vector3 Scale {
            get =>
                _turretTransform.localScale;
            set {
                if (_turretTransform != null)
                    _turretTransform.localScale = value;
            }
        }
        
        public void RotateY(float delta)
        {
            CurrentYRotation += delta;
            CurrentYRotation = Mathf.Clamp(CurrentYRotation, -90f, 90f);
            TurretTransform.localRotation = Quaternion.Euler(0, CurrentYRotation, 0);
        }

        private Transform _turretTransform;
    }
}