using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Core.InputModule.Scripts
{
    public class InputListener : IInputListener, IInitializable, IDisposable
    {
        private const string PlayerActionMap = "Player";
        private const string InteractionAction = "Interaction";
        
        public event Action<Vector2> OnInteractionPerformed;
        public event Action<Vector2> OnInteractionStarted;
        public event Action<Vector2> OnInteractionCanceled;

        public InputListener(InputActionAsset inputActionAsset) =>
            _inputActions = inputActionAsset;

        private readonly InputActionAsset _inputActions;
        private InputAction _interactionAction;

        public void Initialize()
        {
            _inputActions.Enable();
            _interactionAction = _inputActions.FindActionMap(PlayerActionMap).FindAction(InteractionAction);
            _interactionAction.performed += OnInteraction;
            _interactionAction.started += OnInteraction;
            _interactionAction.canceled += OnInteraction;
        }

        public void Dispose()
        {
            _inputActions.Disable();
            _interactionAction.performed -= OnInteraction;
            _interactionAction.started -= OnInteraction;
            _interactionAction.canceled -= OnInteraction;
        }

        public void OnInteraction(InputAction.CallbackContext context)
        {
            if (context.performed)
                OnInteractionPerformed?.Invoke(Mouse.current.position.ReadValue());

            if (context.started)
                OnInteractionStarted?.Invoke(Mouse.current.position.ReadValue());

            if (context.canceled)
                OnInteractionCanceled?.Invoke(Mouse.current.position.ReadValue());
        }

        public void OnNavigate(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnSubmit(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnPoint(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnRightClick(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnMiddleClick(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnScrollWheel(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnTrackedDevicePosition(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }
    }
}