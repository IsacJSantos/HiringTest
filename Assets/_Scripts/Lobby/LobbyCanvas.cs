using HiringTest.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace HiringTest
{
    public class LobbyCanvas : BaseCanvas
    {

        [SerializeField] Button _startGameButton;

        #region MonoBehaviour Callbacks
        protected override void Awake()
        {
            base.Awake();

            Events.AllPlayersReady += OnAllPlayersReady;
            Events.Disconnected += OnDisconnected;
        }

        protected override void OnDestroy()
        {

            Events.AllPlayersReady -= OnAllPlayersReady;
            Events.Disconnected -= OnDisconnected;
            base.OnDestroy();
        }

        #endregion

        public override void ShowCanvas()
        {
           _startGameButton.gameObject.SetActive(NetworkManager.Instance.IsMasterClient);
            base.ShowCanvas();
        }
  

        void OnAllPlayersReady(bool allReady)
        {
            if (!NetworkManager.Instance.IsMasterClient) return;

            ToggleStartGameButton(allReady);

        }
       
        void ToggleStartGameButton(bool interactable)
        {
            print("Toggle Start Game " + interactable);
            _startGameButton.interactable = interactable;
        }

        void OnDisconnected() 
        {
            _startGameButton.interactable = false;
        }

    }

}

