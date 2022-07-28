using UnityEngine;
using BraveHunterGames.Utils;

namespace BraveHunterGames
{
    public abstract class BaseCanvas : MonoBehaviour
    {
        [SerializeField] MenuType _menuType;

        Canvas _canvas;

        #region MonoBehaviour Callbacks
        protected virtual void Awake()
        {
            _canvas = GetComponent<Canvas>();
            Events.OpenMenu += OnOpenMenu;
            Events.HideMenu += OnHideMenu;
        }

        protected virtual void OnDestroy()
        {
            Events.OpenMenu -= OnOpenMenu;
            Events.HideMenu -= OnHideMenu;
        }
        #endregion


        public virtual void OnOpenMenu(MenuType menuType)
        {
            if (menuType == _menuType)
                ShowCanvas();
        }

        public virtual void OnHideMenu(MenuType menuType)
        {
            if (menuType == _menuType)
                HideCanvas();
        }

        public virtual void ShowCanvas()
        {
            _canvas.enabled = true;
        }

        public virtual void HideCanvas()
        {
            _canvas.enabled = false;
        }
    }
}


