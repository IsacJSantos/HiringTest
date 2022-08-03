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
            Events.PlayerLose += OnPlayerLose;
        }

        protected override void OnDestroy()
        {
            Events.PlayerLose -= OnPlayerLose;
            base.OnDestroy();
        }
        #endregion

        void OnPlayerLose(int actorNumber)
        {
            if (NetworkManager.Instance.OwnActorNumber == actorNumber)
            {
                ShowCanvas();
            }
        }
    }
}

