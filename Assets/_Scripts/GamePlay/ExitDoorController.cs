using HiringTest.Utils;
using UnityEngine;


namespace HiringTest 
{
    public class ExitDoorController : MonoBehaviour
    {
        [SerializeField] Animation _anim;

        bool _isOpen;

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            Events.OpenExitDoor += OnOpenExitDoor;
        }

        private void OnDestroy()
        {
            Events.OpenExitDoor -= OnOpenExitDoor;
        }
        #endregion

        public void OnFinishOpenAnimation() 
        {
            print("Door is open");
        }

        void OnOpenExitDoor() 
        {
            if (_isOpen) return;

            _isOpen = true;
            print("Openning exit door...");
            _anim.Play("OpenDoor");
        }

    }
}


