using BraveHunterGames.Utils;
using TMPro;
using UnityEngine;

namespace BraveHunterGames
{
    public class LobbyCanvas : MonoBehaviour
    {
        [SerializeField] string _playerPanelEntryRef; // Reference to find this object in Resources folder
        [SerializeField] Transform _playerListTrans; // 

        [SerializeField] Canvas _canvas;

        bool _isReady;

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            Events.Connected += OnConnect;
            Events.PlayerEnterRoom += OnPlayerEnter;
        }
        private void Start()
        {
            _canvas.enabled = false;
        }
        private void OnDestroy()
        {
            Events.Connected -= OnConnect;
            Events.PlayerEnterRoom -= OnPlayerEnter;
        }

        #endregion

        public void StartGame()
        {
            Events.StartGame?.Invoke();
        }

        public void Ready()
        {
            _isReady = !_isReady;
        }

        public void LeaveRoom()
        {
            Events.Logout?.Invoke();
            _canvas.enabled = false;
        }



        void OnConnect()
        {
            InitPlayerList();
            _canvas.enabled = true;
        }

        void OnPlayerEnter(int actorNumber, string nickName)
        {
            CreatePlayerPanel(actorNumber, nickName);
        }

        void InitPlayerList()
        {
            foreach (var player in NetworkManager.Instance.PlayerList)
            {
                if (player == null) return;

                CreatePlayerPanel(player.ActorNumber, player.NickName);
            }

        }

        PlayerPanelEntry CreatePlayerPanel(int actorNumber, string nickName)
        {
            GameObject ob = Resources.Load<GameObject>(_playerPanelEntryRef);
            if (ob == null)
            {
                Debug.LogError($"Object '{_playerPanelEntryRef}' not found");
                return null;
            }

            PlayerPanelEntry playerPanel = Instantiate(ob, _playerListTrans).GetComponent<PlayerPanelEntry>();
            playerPanel.Init(actorNumber, nickName);
            return playerPanel;
        }
    }

}

