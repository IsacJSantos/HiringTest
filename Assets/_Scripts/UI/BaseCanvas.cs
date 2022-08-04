using UnityEngine;
using DG.Tweening;
using HiringTest.Utils;

/* Base class for all game canvas */

namespace HiringTest
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(Canvas))]
    public abstract class BaseCanvas : MonoBehaviour
    {
        [SerializeField] CanvasType _menuType;
        [SerializeField] protected float _fadeDuration = 0.3f;

        protected Canvas _canvas;
        protected CanvasGroup _canvasGroup;
        protected bool _isOpen;

        #region MonoBehaviour Callbacks
        protected virtual void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _canvasGroup = GetComponent<CanvasGroup>();

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
            _canvasGroup.DOFade(1, _fadeDuration).OnComplete(() =>
            {
                _canvasGroup.interactable = true;
                _canvasGroup.blocksRaycasts = true;
            });
        }

        public virtual void HideCanvas()
        {
            _isOpen = false;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;

            _canvasGroup.DOFade(0, _fadeDuration).OnComplete(() =>
            {
                _canvas.enabled = false;
            });
           
        }
    }
}


