using UnityEngine;
using HiringTest.Utils;

namespace HiringTest
{
    public class PlayerInteractController : MonoBehaviour
    {
        [SerializeField] Camera _cam;
        [SerializeField] float _maxDistance = 5f;

        InputManager _inputManager;
        RaycastHit _hit;
        Ray _ray;

        #region MonoBehaviour Callbacks

        private void Start()
        {
            _inputManager = InputManager.Instance;
        }
        private void Update()
        {
            if (_inputManager.PlayerInteractThisFrame()) Interact();
        }

        #endregion
        public void Init(Camera cam)
        {
            _cam = cam;
        }

        void Interact()
        {
            print("Interact");

            _ray = _cam.ScreenPointToRay(new Vector3(_cam.pixelRect.width / 2, _cam.pixelRect.width / 2, _cam.nearClipPlane));
            if (Physics.Raycast(_ray, out _hit, _maxDistance))
            {
                print("Collid with " + _hit.collider.name);
                IInteractable interactable;
                if (_hit.transform.TryGetComponent<IInteractable>(out interactable))
                {
                    print("Find a interactable");
                    interactable.Interact();
                }
            }
        }
    }
}

