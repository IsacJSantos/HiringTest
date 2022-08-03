using UnityEngine;
using HiringTest.Utils;

namespace HiringTest
{
    public class LoseCanvas : BaseCanvas
    {
        #region MonoBehaviour Callbacks
        protected override void Awake()
        {
            base.Awake();
            Events.PlayerCaptured += OnPlayerCaptured;
        }

        protected override void OnDestroy()
        {
            Events.PlayerCaptured -= OnPlayerCaptured;
            base.OnDestroy();
        }
        #endregion

        void OnPlayerCaptured(int actorNumber)
        {
            if (NetworkManager.Instance.OwnActorNumber == actorNumber)
            {
                ShowCanvas();
            }
        }
    }
}

