using TMPro;
using UnityEngine;
using HiringTest.Utils;
using Photon.Pun;
using UnityEngine.UI;

namespace HiringTest
{
    public class LoginCanvas : BaseCanvas
    {
        [SerializeField] TMP_InputField _inputField;

        const string NICK_NAME_PREF_KEY = "nickName"; // The key of nick name's Player Pref


        #region MonoBehaviour Callbakcs
        protected override void Awake()
        {
            base.Awake();
            Events.ConnectFail += OnConnectFail;
        }

        protected override void OnDestroy()
        {
            Events.ConnectFail -= OnConnectFail;
            base.OnDestroy();
        }

        private void Start()
        {
            string _nickName = string.Empty;
            if (PlayerPrefs.HasKey(NICK_NAME_PREF_KEY))
            {
                _nickName = PlayerPrefs.GetString(NICK_NAME_PREF_KEY);
                _inputField.text = _nickName;
            }

            PhotonNetwork.NickName = _nickName;

            ShowCanvas();
        }
        #endregion


        public void Login()
        {
            NetworkManager.Instance.TryLogin(); // Try put the client online

            Events.OpenCanvas?.Invoke(CanvasType.Connecting);
            HideCanvas();
        }

        public void SavePlayerNickName(string value)
        {
            if (string.IsNullOrEmpty(value)) return;

            PlayerPrefs.SetString(NICK_NAME_PREF_KEY, value);
            PhotonNetwork.NickName = value;
        }


        void OnConnectFail()
        {
            ShowCanvas();
        }


    }
}

