using System;
using Content.Features.CameraModule.Scripts;
using Core.InputModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.InteractionModule.Scripts
{
    internal class InteractRaycastSystem : IInitializable, IDisposable
    {
        private const float MaxDistance = 1000f;
        
        private readonly IInputListener _inputListener;
        private readonly PlayerCameraModel _playerCameraModel;
        private readonly InteractConfiguration _interactConfiguration;

        public InteractRaycastSystem(IInputListener inputListener,
                                     PlayerCameraModel playerCameraModel,
                                     InteractConfiguration interactConfiguration) {
            _playerCameraModel = playerCameraModel;
            _inputListener = inputListener;
            _interactConfiguration = interactConfiguration;
        }

        public void Initialize() => 
            _inputListener.OnInteractionPerformed += HandleRaycast;

        public void Dispose() =>
            _inputListener.OnInteractionPerformed -= HandleRaycast;

        private void HandleRaycast(Vector2 mousePosition) {
            if (_playerCameraModel.CurrentCamera is null)
                return;
            
            Ray ray = _playerCameraModel.CurrentCamera.ScreenPointToRay(mousePosition);
            RaycastHit[] hits = new RaycastHit[_interactConfiguration.MaxHits];

            if (Physics.RaycastNonAlloc(ray, hits, MaxDistance, _interactConfiguration.PlayerInteractLayers) <= 0)
                return;

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider == null || !hit.collider.TryGetComponent(out IInteractable interactable)) continue;
                interactable.Interact();
                return;
            }
        }
    }
}