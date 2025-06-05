using System;
using Core.InputModule.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Content.Features.TurretModule.Scripts
{
    public class TurretInput : IInitializable, ITickable, IDisposable, ITurretInput
    {
        public event Action<float> OnTurretDeltaUpdated; 
        
        private IInputListener _inputListener;
        
        private Vector2 _lastInputPosition;
        private bool _isInteracting;

        public TurretInput(IInputListener inputListener)
        {
            _inputListener = inputListener;
        }

        public void Initialize()
        {
            _inputListener.OnInteractionStarted += OnInteractionStarted;
            _inputListener.OnInteractionPerformed += OnInteractionPerformed;
            _inputListener.OnInteractionCanceled += OnInteractionCanceled;
        }

        public void Dispose()
        {
            _inputListener.OnInteractionStarted -= OnInteractionStarted;
            _inputListener.OnInteractionPerformed -= OnInteractionPerformed;
            _inputListener.OnInteractionCanceled -= OnInteractionCanceled;
        }

        public void Tick()
        {
            if (!_isInteracting || Touchscreen.current == null || !Touchscreen.current.primaryTouch.press.isPressed)
                return;

            Vector2 currentPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector2 delta = currentPosition - _lastInputPosition;
            _lastInputPosition = currentPosition;

            float sensitivity = 0.15f;
            float deltaY = delta.x * sensitivity;
            OnTurretDeltaUpdated?.Invoke(deltaY);
        }

        private void OnInteractionStarted(Vector2 screenPos)
        {
            _lastInputPosition = screenPos;
            _isInteracting = true;
        }

        private void OnInteractionPerformed(Vector2 screenPos)
        {
            if (!_isInteracting) return;

            Vector2 delta = screenPos - _lastInputPosition;
            _lastInputPosition = screenPos;

            float sensitivity = 0.1f;
            float deltaY = delta.x * sensitivity;
            OnTurretDeltaUpdated?.Invoke(deltaY);
        }

        private void OnInteractionCanceled(Vector2 screenPos) 
            => _isInteracting = false;
    }
}