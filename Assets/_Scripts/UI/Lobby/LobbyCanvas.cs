using HiringTest.Utils;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HiringTest
{
    public class LobbyCanvas : BaseCanvas
    {
        [SerializeField] Button _startGameButton;
        [SerializeField] TextMeshProUGUI _readyButtonText;

        const string READY_TEXT = "Ready";
        const string UNREADY_TEXT = "Unready";

        NetworkManager _networkManager;

        #region MonoBehaviour Callbacks
        protected override void Awake()
        {
            base.Awake();

            Events.AllPlayersReady += OnAllPlayersReady;
            Events.Disconnected += OnDisconnected;
            Events.MasterClientSwitched += OnMasterClientSwitched;
            Events.SetPlayerReady += OnSetPlayerReady;

            _networkManager = NetworkManager.Instance;
        }

        protected override void OnDestroy()
        {

            Events.AllPlayersReady -= OnAllPlayersReady;
            Events.Disconnected -= OnDisconnected;
            Events.MasterClientSwitched -= OnMasterClientSwitched;
            Events.SetPlayerReady -= OnSetPlayerReady;

            base.OnDestroy();
        }

        #endregion

        public override void ShowCanvas()
        {
            ToggleStartButtonActive(_networkManager.IsMasterClient);
            _readyButtonText.text = READY_TEXT;
            base.ShowCanvas();
        }

        void OnSetPlayerReady(int actorNumber, bool ready) // Update Ready Button text
        {
            bool isThisClient = actorNumber == _networkManager.OwnActorNumber;

            if (isThisClient) 
            {
                _readyButtonText.text = ready ? UNREADY_TEXT : READY_TEXT;
            }
        }

        void OnAllPlayersReady(bool allReady)
        {
            if (!_networkManager.IsMasterClient) return;

            ToggleStartButtonInteractable(allReady);

        }

        void OnDisconnected()
        {
            _startGameButton.interactable = false;
        }

        void OnMasterClientSwitched(int actorNumber)
        {
            bool isThisClient = actorNumber == _networkManager.OwnActorNumber;
            
            if (isThisClient)
            {
                ToggleStartButtonActive(true);
            }
        }

        void ToggleStartButtonInteractable(bool interactable)
        {
            _startGameButton.interactable = interactable;
        }

        void ToggleStartButtonActive(bool active)
        {
            _startGameButton.gameObject.SetActive(active);
        }
    }

}

