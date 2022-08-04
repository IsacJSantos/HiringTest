using UnityEngine;
using HiringTest.Utils;

namespace HiringTest 
{
    public class ComputerController : MonoBehaviour, IInteractable
    {
        [SerializeField] Material _doorOpenMaterial;
        
        Renderer _renderer;
        bool _doorIsOpen;

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            Events.OpenExitDoor += OnOpenExitDoor;

            _renderer = GetComponent<Renderer>();
        }

        private void OnDestroy()
        {
            Events.OpenExitDoor -= OnOpenExitDoor;
        }

        #endregion

        public void Interact()
        {
            if (_doorIsOpen) return;

            _doorIsOpen = true;
            Events.ShowExitDoorOpening?.Invoke();
            NetworkManager.Instance.CallOpenExitDoorRPC();
            _renderer.material = _doorOpenMaterial;
        }

        void OnOpenExitDoor() 
        {
            _doorIsOpen = true;
        }


    }
}

