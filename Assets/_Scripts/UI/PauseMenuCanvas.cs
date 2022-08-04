using UnityEngine;
using HiringTest.Utils;
using DG.Tweening;

namespace HiringTest
{
    public class PauseMenuCanvas : BaseCanvas
    {
        [SerializeField] RectTransform _contaienerRt;

        Tween _tween;
        #region MonoBehaviour Callbacks
       
        #endregion

        public override void ShowCanvas()
        {
            _isOpen = true;
            ToggleSideMenu(true);
        }


        public override void HideCanvas()
        {
            _isOpen = false;
            ToggleSideMenu(false);
        }

        void ToggleSideMenu(bool show)
        {
            Events.Paused?.Invoke(show);

            float from = show ? 0 : 1;
            int to = show ? 1 : -1;

            if (_tween != null)
                DOTween.Kill(_tween);

            _tween = DOTween.To(() => from, x => from = x, to, _fadeDuration).OnUpdate(() =>
            {
                _contaienerRt.anchorMin = new Vector2(from - 1, 0);
                _contaienerRt.anchorMax = new Vector2(from, 1);
            });
        }

    }

}
