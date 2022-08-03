using UnityEngine;

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
            _renderer = GetComponent<Renderer>();
          
        }


        #endregion

        public void Interact()
        {
            if (_doorIsOpen) return;

            NetworkManager.Instance.CallOpenExitDoorRPC();
            _doorIsOpen = true;
            _renderer.material = _doorOpenMaterial;

        }
    }
}

