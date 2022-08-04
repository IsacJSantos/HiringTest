using UnityEngine;
using HiringTest.Utils;
using TMPro;

namespace HiringTest
{
    public class ConnectingPanel : BaseCanvas
    {

        [SerializeField] TextMeshProUGUI _connectingText;

        const string CONNECTING_TEXT = "Connecting...";
        const string CONNECTED_TEXT = "Connected";
        const string NOT_CONNECTED_TEXT = "Not connected";

        #region MonoBehaviour Callbacks

        protected override void Awake()
        {
            base.Awake();

            Events.Connected += OnConnected;
            Events.ConnectFail += OnConnecteFail;
        }

        protected override void OnDestroy()
        {
            Events.Connected -= OnConnected;
            Events.ConnectFail -= OnConnecteFail;

            base.OnDestroy();
        }

        #endregion

        public override void OnOpenMenu(CanvasType menuType)
        {
            InitConnectingCanvas();
            base.OnOpenMenu(menuType);
        }

        void InitConnectingCanvas()
        {
            _connectingText.color = Color.yellow;
            _connectingText.text = CONNECTING_TEXT;
        }

        void OnConnected()
        {
            _connectingText.color = Color.green;
            _connectingText.text = CONNECTED_TEXT;
        }

        void OnConnecteFail()
        {
            _connectingText.color = Color.red;
            _connectingText.text = NOT_CONNECTED_TEXT;
        }



    }
}

