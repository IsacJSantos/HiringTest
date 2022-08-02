using UnityEngine;
using HiringTest.Utils;

namespace HiringTest
{
    public abstract class BaseCanvas : MonoBehaviour
    {
        [SerializeField] CanvasType _menuType;

        protected Canvas _canvas;
        bool _isOpen;

        #region MonoBehaviour Callbacks
        protected virtual void Awake()
        {
            _canvas = GetComponent<Canvas>();
            Events.OpenCanvas += OnOpenMenu;
            Events.HideCanvas += OnHideMenu;
        }

        protected virtual void OnDestroy()
        {
            Events.OpenCanvas -= OnOpenMenu;
            Events.HideCanvas -= OnHideMenu;
        }
        #endregion


        public virtual void OnOpenMenu(CanvasType menuType)
        {
            if (_isOpen) return;

            if (menuType == _menuType)
                ShowCanvas();
        }

        public virtual void OnHideMenu(CanvasType menuType)
        {
            if (!_isOpen) return;

            if (menuType == _menuType)
                HideCanvas();
        }

        public virtual void ShowCanvas()
        {
            _isOpen = true;
            _canvas.enabled = true;
        }

        public virtual void HideCanvas()
        {
            _isOpen = false;
            _canvas.enabled = false;
        }
    }
}


