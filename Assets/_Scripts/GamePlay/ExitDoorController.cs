using HiringTest.Utils;
using UnityEngine;
using Cinemachine;

namespace HiringTest 
{
    public class ExitDoorController : MonoBehaviour
    {
        [SerializeField] Animation _anim;
        [SerializeField] CinemachineVirtualCamera _vCam;
        bool _isOpen;

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            Events.OpenExitDoor += OnOpenExitDoor;
            Events.ShowExitDoorOpening += OnShowExitDoorOpenning;
            _vCam.enabled = false;
        }

        private void OnDestroy()
        {
            Events.OpenExitDoor -= OnOpenExitDoor;
            Events.ShowExitDoorOpening -= OnShowExitDoorOpenning;
        }
        #endregion

        public void OnFinishOpenAnimation() 
        {
            _vCam.enabled = false;
        }

        void OnOpenExitDoor() // Called remotely
        {
            if (_isOpen) return;

            _isOpen = true;
            _anim.Play("OpenDoor");
        }

        void OnShowExitDoorOpenning() // Called locally
        {
            _vCam.enabled = true;
            _anim.Play("OpenDoor");
        }

    }
}


