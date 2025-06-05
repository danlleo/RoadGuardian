using System;
using UnityEngine;

namespace Content.Features.CameraModule.Scripts
{
    public class PlayerCameraModel
    {
        public event Action<Camera> OnPlayerCameraChanged;
        
        public Camera CurrentCamera
        {
            get => _currentCamera;
            set
            {
                OnPlayerCameraChanged?.Invoke(value);
                _currentCamera = value;
            }
        }
        
        private Camera _currentCamera;
    }
}