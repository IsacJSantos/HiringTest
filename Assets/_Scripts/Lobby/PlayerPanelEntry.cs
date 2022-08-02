using HiringTest.Utils;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace HiringTest
{
    public class PlayerPanelEntry : MonoBehaviour
    {
        public bool IsReady;
        public int ActorNumber => _actorNumber;

        [SerializeField] TextMeshProUGUI _nickNameText;
        [SerializeField] TextMeshProUGUI _readyText;

        [SerializeField] Image _bottonLineImg;
        [SerializeField] Image _readyBg;

        int _actorNumber;

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            Events.PlayerLeftRoom += OnPlayerLeft;
            Events.SetPlayerReady += OnSetPlayerReady;
            Events.Logout += OnLogout;
        }

        private void OnDestroy()
        {
            Events.PlayerLeftRoom -= OnPlayerLeft;
            Events.SetPlayerReady -= OnSetPlayerReady;
            Events.Logout -= OnLogout;
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
                Destroy(gameObject);
            }
        }

        void OnSetPlayerReady(int actorNumber, bool isReady)
        {
            if (actorNumber == _actorNumber)
            {
                IsReady = isReady;
                _readyText.text = isReady ? "Ready" : "Unready";
                _bottonLineImg.color = isReady ? Color.green : Color.red;
                _readyBg.color = isReady ? Color.green : Color.red;
                Events.PlayerReady?.Invoke(actorNumber, IsReady);
            }

        }

        void OnLogout() 
        {
           Destroy(gameObject);
        }
    }
}

