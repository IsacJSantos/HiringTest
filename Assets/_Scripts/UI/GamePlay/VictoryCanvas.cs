using HiringTest.Utils;

namespace HiringTest
{
    public class VictoryCanvas : BaseCanvas
    {
        #region MonoBehaviour Callbacks
        protected override void Awake()
        {
            base.Awake();
            Events.PlayerEscaped += OnPlayerEscaped;
        }

        protected override void OnDestroy()
        {
            Events.PlayerEscaped -= OnPlayerEscaped;
            base.OnDestroy();
        }
        #endregion

        void OnPlayerEscaped(int actorNumber)
        {
            bool isThisClient = actorNumber == NetworkManager.Instance.OwnActorNumber;

            if (isThisClient)
            {
                ShowCanvas();
            }
        }
    }
}

