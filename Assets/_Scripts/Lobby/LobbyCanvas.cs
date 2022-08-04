using HiringTest.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace HiringTest
{
    public class LobbyCanvas : BaseCanvas
    {
        [SerializeField] Button _startGameButton;

        NetworkManager _networkManager;

        #region MonoBehaviour Callbacks
        protected override void Awake()
        {
            base.Awake();

            Events.AllPlayersReady += OnAllPlayersReady;
            Events.Disconnected += OnDisconnected;
            Events.MasterClientSwitched += OnMasterClientSwitched;

            _networkManager = NetworkManager.Instance;
        }

        protected override void OnDestroy()
        {

            Events.AllPlayersReady -= OnAllPlayersReady;
            Events.Disconnected -= OnDisconnected;
            Events.MasterClientSwitched -= OnMasterClientSwitched;

            base.OnDestroy();
        }

        #endregion

        public override void ShowCanvas()
        {
           _startGameButton.gameObject.SetActive(_networkManager.IsMasterClient);
            base.ShowCanvas();
        }
  

        void OnAllPlayersReady(bool allReady)
        {
            if (!_networkManager.IsMasterClient) return;

            ToggleStartGameButton(allReady);

        }
       
        void ToggleStartGameButton(bool interactable)
        {
            _startGameButton.interactable = interactable;
        }

        void OnDisconnected() 
        {
            _startGameButton.interactable = false;
        }

        void OnMasterClientSwitched(int actorNumber) 
        {
            if (actorNumber == _networkManager.OwnActorNumber)
            {
                _startGameButton.gameObject.SetActive(true);
            }
        }
    }

}

