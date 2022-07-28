using TMPro;
using UnityEngine;
using BraveHunterGames.Utils;
using Photon.Pun;
using UnityEngine.UI;

namespace BraveHunterGames
{
    public class LoginCanvas : MonoBehaviour
    {
        [SerializeField] TMP_InputField _inputField;
        [SerializeField] Canvas _loginPanelCv;
        [SerializeField] Canvas _connectingPanelCv;

        const string NICK_NAME_PREF_KEY = "nickName"; // The key of nick name's Player Pref


        #region MonoBehaviour Callbakcs
        private void Awake()
        {
            Events.Connected += OnConnected;
        }

        private void OnDestroy()
        {
            Events.Connected -= OnConnected;
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

            _loginPanelCv.enabled = true;
            _connectingPanelCv.enabled = false;
        }
        #endregion


        public void Login()
        {
            Events.Login?.Invoke();
            _loginPanelCv.enabled = false;
            _connectingPanelCv.enabled = true;
        }

        public void SavePlayerNickName(string value)
        {
            if (string.IsNullOrEmpty(value)) return;

            PlayerPrefs.SetString(NICK_NAME_PREF_KEY, value);
            PhotonNetwork.NickName = value;
        }

        void OnConnected() 
        {
          //  _connectingPanelCv.enabled = false;
        }
    }
}

