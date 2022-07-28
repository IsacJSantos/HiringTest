using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using BraveHunterGames.Utils;

namespace BraveHunterGames
{

    public class Launcher : MonoBehaviourPunCallbacks
    {

        [SerializeField]
        private byte maxPlayersPerRoom = 2;

        string gameVersion = "1";

        #region MonoBehaviour Callbacks
        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            Events.Login += OnTryLogin;

        }

        private void OnDestroy()
        {
            Events.Login -= OnTryLogin;
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

        #endregion

        public void Connect()
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


        void OnTryLogin()
        {
            Connect();
        }


    }
}

