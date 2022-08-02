using UnityEngine.InputSystem;
using HiringTest.Utils;
using UnityEngine;

namespace HiringTest 
{
    public class InputManager : Singleton<InputManager>
    {
        Input _inputControll;

        #region Monobehaviour Callbacks
        protected override void Awake()
        {
            base.Awake();
            _inputControll = new Input();
        }
        private void OnEnable()
        {
            _inputControll.Enable();
        }

        private void OnDisable()
        {
            _inputControll.Disable();
        }
        #endregion

        #region Player Controller
        public Vector2 GetPlayerMoveX()
        {
            return _inputControll.PlayerControl.XMove.ReadValue<Vector2>();
        }

        public Vector2 GetPlayerMoveY()
        {
            return _inputControll.PlayerControl.YMove.ReadValue<Vector2>();
        }

        public Vector2 GetMouseDelta()
        {
            return _inputControll.PlayerControl.Look.ReadValue<Vector2>();
        }
        public bool PlayerInteractThisFrame()
        {
            return _inputControll.PlayerControl.Interact.triggered;
        }

        public bool PlayerRunThisFrame()
        {
            return _inputControll.PlayerControl.Run.triggered;
        }
        #endregion

        #region PauseMenu 
        public bool PressedPauseThisFrame() 
        {
            return _inputControll.UI.PauseMenu.triggered;
        }
        #endregion

    }
}

