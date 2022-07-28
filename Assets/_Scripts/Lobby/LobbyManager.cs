using BraveHunterGames.Utils;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace BraveHunterGames
{
    public class LobbyManager : MonoBehaviour
    {
        [SerializeField] string _playerPanelEntryRef; // Reference to find this object in Resources folder
        [SerializeField] Transform _playerListTrans;
        
        bool _isReady;
        List<PlayerPanelEntry> _playerPanels = new List<PlayerPanelEntry>();

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            Events.Connected += OnConnect;
            Events.PlayerReady += OnPlayerReady;
            Events.PlayerEnterRoom += OnPlayerEnter;
            Events.PlayerLeftRoom += OnPlayerLeft;

        }

        private void OnDestroy()
        {
            Events.Connected -= OnConnect;
            Events.PlayerReady -= OnPlayerReady;
            Events.PlayerEnterRoom -= OnPlayerEnter;
            Events.PlayerLeftRoom -= OnPlayerLeft;
        }

        #endregion

        public void StartGame()
        {
            Events.StartGame?.Invoke();
            Events.HideMenu?.Invoke(MenuType.Lobby);
            NetworkManager.Instance.LoadScene(1);
        }

        public void Ready()
        {

            _isReady = !_isReady;
            NetworkManager.Instance.CallPlayerReady(NetworkManager.Instance.OwnActorNumber, _isReady);
        }

        public void LeaveRoom()
        {
            NetworkManager.Instance.LeaveRoom();
            Events.Logout?.Invoke();
            Events.HideMenu?.Invoke(MenuType.Lobby);
        }


        void OnConnect()
        {
            InitPlayerList();
            Events.OpenMenu?.Invoke(MenuType.Lobby);
        }

        void OnPlayerEnter(int actorNumber, string nickName)
        {
            _playerPanels.Add(CreatePlayerPanel(actorNumber, nickName));
            CheckPlayersReady();
        }

        void OnPlayerLeft(int actorNumber, string nickName)
        {
            PlayerPanelEntry playerPanel = _playerPanels.FirstOrDefault(x => x.ActorNumber == actorNumber);
            if (playerPanel != null)
                _playerPanels.Remove(playerPanel);

            CheckPlayersReady();
        }


        void OnPlayerReady(int actorNumber, bool ready)
        {
            CheckPlayersReady();
        }

        void CheckPlayersReady()
        {
            if (!NetworkManager.Instance.IsMasterClient) return;

            Events.AllPlayersReady?.Invoke(IsAllPlayersReady());
        }

        bool IsAllPlayersReady()
        {
            int count = _playerPanels.Count;
            for (int i = 0; i < count; i++)
            {
                if (_playerPanels[i].IsReady == false)
                    return false;
            }
            return true;
        }

        void InitPlayerList()
        {
            foreach (var player in NetworkManager.Instance.PlayerList)
            {
                if (player == null) return;
                _playerPanels.Add(CreatePlayerPanel(player.ActorNumber, player.NickName));
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


