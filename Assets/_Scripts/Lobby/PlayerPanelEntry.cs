using BraveHunterGames.Utils;
using UnityEngine;
using TMPro;

namespace BraveHunterGames
{
    public class PlayerPanelEntry : MonoBehaviour
    {
        public bool IsReady;
        public int ActorNumber => _actorNumber;

        [SerializeField] TextMeshProUGUI _nickNameText;
        [SerializeField] TextMeshProUGUI _readyText;

        [SerializeField] int _actorNumber;

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            Events.PlayerLeftRoom += OnPlayerLeft;
            Events.SetPlayerReady += OnSetPlayerReady;
        }

        private void OnDestroy()
        {
            Events.PlayerLeftRoom -= OnPlayerLeft;
            Events.SetPlayerReady -= OnSetPlayerReady;
        }
        #endregion

        public void Init(int actorNumber, string nickName)
        {
            _nickNameText.text = nickName;
            _actorNumber = actorNumber;
        }



        void OnPlayerLeft(int actorNumber, string nickName)
        {
            if (actorNumber == _actorNumber)
            {
                gameObject.SetActive(false);
            }
        }

        void OnSetPlayerReady(int actorNumber, bool ready)
        {
            if (actorNumber == _actorNumber)
            {
                IsReady = ready;
                _readyText.text = IsReady ? "Ready" : "Unready";
                Events.PlayerReady?.Invoke(actorNumber, IsReady);
            }

        }
    }
}

