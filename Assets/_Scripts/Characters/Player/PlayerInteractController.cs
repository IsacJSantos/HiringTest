using UnityEngine;
using HiringTest.Utils;

namespace HiringTest
{
    public class PlayerInteractController : MonoBehaviour
    {
        [SerializeField] Camera _cam;
        [SerializeField] float _maxDistance = 5f;
        [SerializeField] LayerMask _visibleLayers;

        IInteractable _interactable;
        InputManager _inputManager;
        RaycastHit _hit;
        Ray _ray;
        Vector3 _screenPoint;

        Transform _currentTransform; // Current object captured by the ray

        bool _isEnable;

        #region MonoBehaviour Callbacks

        private void Update()
        {
            if (!_isEnable) return;

            if (_inputManager.PlayerInteractThisFrame()) Interact();
        }

        private void LateUpdate()
        {
            if (!_isEnable) return;

            CheckInteractable();
        }

        #endregion

        public void Init(Camera cam)
        {
            _cam = cam;
            _screenPoint = new Vector3(_cam.pixelRect.width / 2, _cam.pixelRect.width / 2, _cam.nearClipPlane);
            _inputManager = InputManager.Instance;
            _isEnable = true;
        }

        void Interact()
        {
            _interactable?.Interact();
        }

        void CheckInteractable() 
        {
            _ray = _cam.ScreenPointToRay(_screenPoint);
            if (Physics.Raycast(_ray, out _hit, _maxDistance, _visibleLayers))
            {
                if (_currentTransform != null && _currentTransform == _hit.transform) return; // This object is already verified

                _currentTransform = _hit.transform;

                if (!_hit.transform.TryGetComponent<IInteractable>(out _interactable)) // Checks if this object is an Interactable
                {
                    Events.HideCanvas?.Invoke(CanvasType.Interact);
                    _interactable = null;
                }
                else
                    Events.OpenCanvas?.Invoke(CanvasType.Interact);

            }
            else if (_interactable != null) // Clean Interactable out of view
            {
                Events.HideCanvas?.Invoke(CanvasType.Interact);
                _currentTransform = null;
                _interactable = null;
            }
        }
    }
}

