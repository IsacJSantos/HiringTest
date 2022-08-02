using HiringTest.Utils;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

namespace HiringTest
{
    public class LobbyManager : MonoBehaviour
    {
        [SerializeField] string _playerPanelEntryRef; // Reference to find this object in Resources folder
        [SerializeField] Transform _playerListTrans;
        [SerializeField] TextMeshProUGUI _readyButtonText;
        [SerializeField] Image _loadLevelScreemImg;

        bool _isReady;
        const string READY_TEXT = "Ready";
        const string UNREADY_TEXT = "Unready";
        List<PlayerPanelEntry> _playerPanels = new List<PlayerPanelEntry>();

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            Events.Connected += OnConnect;
            Events.PlayerReady += OnPlayerReady;
            Events.PlayerEnterRoom += OnPlayerEnter;
            Events.PlayerLeftRoom += OnPlayerLeft;
            Events.StartGameLoadingScreen += OnStartGameLoadingScreen;

        }

        private void OnDestroy()
        {
            Events.Connected -= OnConnect;
            Events.PlayerReady -= OnPlayerReady;
            Events.PlayerEnterRoom -= OnPlayerEnter;
            Events.PlayerLeftRoom -= OnPlayerLeft;
            Events.StartGameLoadingScreen -= OnStartGameLoadingScreen;
        }

        #endregion

        public void StartGame()
        {
            Events.StartGame?.Invoke();
            NetworkManager.Instance.CallStartGameLoadScreen();
        }

        public void Ready()
        {
            _isReady = !_isReady;
            _readyButtonText.text = _isReady ? UNREADY_TEXT : READY_TEXT;
            NetworkManager.Instance.CallPlayerReady(NetworkManager.Instance.OwnActorNumber, _isReady);
        }

        public void LeaveRoom()
        {
            NetworkManager.Instance.LeaveGame(); // Put the client offline

            Events.Logout?.Invoke();
            Events.HideCanvas?.Invoke(CanvasType.Lobby);
            Events.HideCanvas?.Invoke(CanvasType.Connecting);
            Events.OpenCanvas?.Invoke(CanvasType.Login);
        }


        void OnConnect()
        {
            InitPlayerList();

            _isReady = false;
            _readyButtonText.text = READY_TEXT;
            Events.OpenCanvas?.Invoke(CanvasType.Lobby);
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

        void OnStartGameLoadingScreen() //Dims the screen to load the gameplay level
        {
            BGMManager.Instance.StopMusic();

            _loadLevelScreemImg.DOFade(1, 0.6f).OnComplete(() =>
            {
                if (NetworkManager.Instance.IsMasterClient)
                    NetworkManager.Instance.LoadScene(SceneType.Gameplay);
            });
        }

    }
}


