using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using HiringTest.Utils;
using System.Collections.Generic;
using System.Linq;

namespace HiringTest
{
    [DisallowMultipleComponent]
    public class NetworkManager : SingletonPunCallback<NetworkManager>
    {
        public Player[] PlayerList => _playerList.ToArray();
        public int OwnActorNumber => _ownActorNumber;

        public bool IsMasterClient => PhotonNetwork.IsMasterClient;

        [SerializeField] private byte maxPlayersPerRoom = 2;
        [SerializeField] List<Player> _playerList;
        [SerializeField] int _ownActorNumber;

        string gameVersion = "1";


        #region MonoBehaviour Callbacks

        protected override void Awake()
        {
            base.Awake();
            PhotonNetwork.AutomaticallySyncScene = true;
        }


        #endregion

        #region Photon Callbacks

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to Master");
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log("Disconnected");
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("Could not find a room.");
            PhotonNetwork.CreateRoom(null, new RoomOptions()
            {
                MaxPlayers = maxPlayersPerRoom,
                PublishUserId = true
            });
        }


        public override void OnJoinedRoom()
        {
            Debug.Log("Joined in a room");

            _ownActorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
            _playerList = PhotonNetwork.PlayerList.ToList();
            Events.Connected?.Invoke();
        }


        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Events.ConnectFail?.Invoke();
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Events.PlayerEnterRoom?.Invoke(newPlayer.ActorNumber, newPlayer.NickName);
            _playerList.Add(newPlayer);

        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            Events.PlayerLeftRoom?.Invoke(otherPlayer.ActorNumber, otherPlayer.NickName);
            _playerList.Remove(otherPlayer);
        }
        #endregion

        #region Geneal Methods
        public void LeaveGame()
        {
            PhotonNetwork.Disconnect();
            Events.Disconnected?.Invoke();
        }

        public void LoadScene(SceneType sceneType)
        {
            PhotonNetwork.LoadLevel((int)sceneType);
        }

        public void SetRoomVisibility(bool open)
        {
            PhotonNetwork.CurrentRoom.IsOpen = open;
        }

        public GameObject InstantiateNetworkObject(string prefabName, Vector3 pos)
        {
            return PhotonNetwork.Instantiate(prefabName, pos, Quaternion.identity);
        }

        #endregion

        #region Lobby Methods

        public void TryLogin()
        {
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
        }

        public void CallPlayerReady(int actorNumber, bool ready)
        {
            this.photonView.RPC("SetPlayerReady", RpcTarget.AllBuffered, actorNumber, ready);
        }

        public void CallStartGameLoadScreen()
        {
            this.photonView.RPC("InitLoadLevelScreen", RpcTarget.AllBuffered);
        }

        [PunRPC]
        void SetPlayerReady(int actorNumber, bool ready) // Set the Ready/Unready player on lobby by RPC
        {
            Events.SetPlayerReady?.Invoke(actorNumber, ready);
        }

        [PunRPC]
        void InitLoadLevelScreen() // Dims the screen before load a level
        {
            Events.StartGameLoadingScreen?.Invoke();
        }

        #endregion

        #region GamePlay Methods

        public void CallEnemyTriggerAnimRPC(TriggerAnimType animType)
        {
            this.photonView.RPC("SetEnemyTriggerAnim", RpcTarget.All, (int)animType);
        }

        public void CallEnemyInitStateRPC(StateType enemyState)
        {
            this.photonView.RPC("SetEnemyInitState", RpcTarget.All, (int)enemyState);
        }

        public void CallPlayerCapturedRPC(int actorNumber) // When a player is captured by the enemy
        {
            this.photonView.RPC("PlayerCaptured", RpcTarget.All, actorNumber);
        }

        public void CallOpenExitDoorRPC() 
        {
            this.photonView.RPC("OpenExitDoor", RpcTarget.All);
        }

        public void CallPlayerEscapedRPC(int actorNumber) 
        {
            this.photonView.RPC("PlayerEscaped", RpcTarget.All, actorNumber);
        }

        [PunRPC]
        void SetEnemyTriggerAnim(int anim)
        {
            Events.SetEnemyTriggerAnim?.Invoke((TriggerAnimType)anim);
        }

        [PunRPC]
        void SetEnemyInitState(int state)
        {
            Events.EnemyInitState?.Invoke((StateType)state);
        }

        [PunRPC]
        void PlayerCaptured(int actorNumber)
        {
            Events.PlayerCaptured?.Invoke(actorNumber);
        }

        [PunRPC]
        void OpenExitDoor()
        {
            Events.OpenExitDoor?.Invoke();
        }

        [PunRPC]
        void PlayerEscaped(int actorNumber) 
        {
            Events.PlayerEscaped?.Invoke(actorNumber);
        }

        #endregion


    }
}

