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
            Events.PlayerEscaped += DisablePlayerMovement;
            Events.PlayerCaptured += DisablePlayerMovement;
            Events.Paused += OnGamePaused;

            _inputControll = new Input();
            Cursor.visible = false;
        }

        protected override void OnDestroy()
        {
            Events.PlayerEscaped -= DisablePlayerMovement;
            Events.PlayerCaptured -= DisablePlayerMovement;
            Events.Paused -= OnGamePaused;

            base.OnDestroy();
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


        void DisablePlayerMovement(int actorNumber)
        {
            bool isThisClient = actorNumber == NetworkManager.Instance.OwnActorNumber;
            if (isThisClient)
            {
                Cursor.visible = true;
                _inputControll.PlayerControl.Disable();
            }
        }

        void OnGamePaused(bool paused)
        {
            if (paused)
            {
                _inputControll.PlayerControl.Disable();
                Cursor.visible = true;
            }
            else
            {
                Cursor.visible = false;
                _inputControll.PlayerControl.Enable();
            }
        }
    }
}

