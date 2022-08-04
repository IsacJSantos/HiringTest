using UnityEngine;
using HiringTest.Utils;

namespace HiringTest
{
    public class PlayerInteractController : MonoBehaviour
    {
        [SerializeField] Camera _cam;
        [SerializeField] float _maxDistance = 5f;
        [SerializeField] LayerMask _visibleLayers;
        [SerializeField] /*PlayerManager*/ PlayerMovementController _playerController;

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

            _ray = _cam.ScreenPointToRay(_screenPoint);
            if (Physics.Raycast(_ray, out _hit, _maxDistance, _visibleLayers))
            {
                if (_currentTransform != null && _currentTransform == _hit.transform) return; // This object is already verified

                _currentTransform = _hit.transform;

                if (!_hit.transform.TryGetComponent<IInteractable>(out _interactable))
                    _interactable = null;
            }
            else
            {
                _currentTransform = null;
                _interactable = null;
            }

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
    }
}

