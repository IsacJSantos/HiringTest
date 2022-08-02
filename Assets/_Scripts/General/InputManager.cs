using UnityEngine.InputSystem;
using HiringTest.Utils;
using UnityEngine;

namespace HiringTest 
{
    public class InputManager : Singleton<InputManager>
    {
        Input _playerControls;

        #region Monobehaviour Callbacks
        protected override void Awake()
        {
            base.Awake();
            _playerControls = new Input();
        }
        private void OnEnable()
        {
            _playerControls.Enable();
        }

        private void OnDisable()
        {
            _playerControls.Disable();
        }
        #endregion

        public Vector2 GetPlayerMoveX() 
        {
            return _playerControls.PlayerControl.XMove.ReadValue<Vector2>();
        }

        public Vector2 GetPlayerMoveY()
        {
            return _playerControls.PlayerControl.YMove.ReadValue<Vector2>();
        }

        public Vector2 GetMouseDelta() 
        {
            return _playerControls.PlayerControl.Look.ReadValue<Vector2>();
        }
        public bool PlayerInteractThisFrame() 
        {
            return _playerControls.PlayerControl.Interact.triggered;
        }

        public bool PlayerRunThisFrame()
        {
            return _playerControls.PlayerControl.Run.triggered;
        }
    }
}

