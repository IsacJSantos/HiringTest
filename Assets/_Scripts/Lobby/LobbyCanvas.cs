using BraveHunterGames.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BraveHunterGames
{
    public class LobbyCanvas : BaseCanvas
    {

        [SerializeField] Button _startGameButton;

        #region MonoBehaviour Callbacks
        protected override void Awake()
        {
            base.Awake();

            Events.AllPlayersReady += OnAllPlayersReady;
        }

        protected override void OnDestroy()
        {

            Events.AllPlayersReady -= OnAllPlayersReady;
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
            _startGameButton.interactable = interactable;
        }

    }

}

