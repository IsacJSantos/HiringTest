using HiringTest.Utils;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

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
        float _colorChangeDuration = 0.45f;

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
                SetPanelVisual(IsReady);
                Events.PlayerReady?.Invoke(actorNumber, IsReady);
            }

        }

        void OnLogout() 
        {
           Destroy(gameObject);
        }

        void SetPanelVisual(bool ready) 
        {
            Color toColor = ready ? Color.green : Color.red;

            _readyText.text = ready ? "Ready" : "Unready";
            _readyBg.DOColor(toColor, _colorChangeDuration);
            _bottonLineImg.DOColor(toColor, _colorChangeDuration);
        }
    }
}

