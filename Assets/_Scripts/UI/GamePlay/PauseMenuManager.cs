using UnityEngine;
using HiringTest.Utils;

namespace HiringTest
{
    public class PauseMenuManager : MonoBehaviour
    {
        bool _toggleMenu;

        #region MonoBehaviour Callbacks
        private void Update()
        {
            if (InputManager.Instance.PressedPauseThisFrame()) 
            {
                _toggleMenu = !_toggleMenu;
                if (_toggleMenu)
                    Events.OpenCanvas(CanvasType.Pause);
                else
                    Events.HideCanvas(CanvasType.Pause);
            }
        }
        #endregion
    }

}
