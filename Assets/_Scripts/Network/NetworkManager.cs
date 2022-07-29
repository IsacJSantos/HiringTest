using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using BraveHunterGames.Utils;
using System.Collections.Generic;
using System.Linq;

namespace BraveHunterGames
{
    [DisallowMultipleComponent]
    public class NetworkManager : SingletonPunCallback<NetworkManager>
    {
        public Player[] PlayerList => _playerList.ToArray();
        public int OwnActorNumber => _ownActorNumber;

        public bool IsMasterClient => PhotonNetwork.IsMasterClient;

        [SerializeField] List<Player> _playerList;
        [SerializeField] int _ownActorNumber;


        #region MonoBehaviour Callbacks

        #endregion

        #region Photon Callbacks


        public override void OnJoinedRoom()
        {
            Debug.Log("Joined in a room");

            _ownActorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
            _playerList = PhotonNetwork.PlayerList.ToList();
            Events.Connected?.Invoke();
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

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public void LoadScene(int sceneIndex)
        {
            PhotonNetwork.LoadLevel(sceneIndex);
        }

        #region Lobby Methods

        public void CallPlayerReady(int actorNumber, bool ready)
        {
            this.photonView.RPC("SetPlayerReady", RpcTarget.AllBuffered, actorNumber, ready);
        }

        public void InstantiateNetworkObject(string prefabName, Vector3 pos)
        {
            PhotonNetwork.Instantiate(prefabName, pos, Quaternion.identity);
        }


        [PunRPC]
        void SetPlayerReady(int actorNumber, bool ready)
        {
            Events.SetPlayerReady?.Invoke(actorNumber, ready);
        }

        #endregion

        #region GamePlay Methods
        public void CallEnemyTriggerAnim(TriggerAnimType animType)
        {
            this.photonView.RPC("SetEnemyTriggerAnim", RpcTarget.All, (int)animType);
        }

        [PunRPC]
        void SetEnemyTriggerAnim(int anim)
        {
            Events.SetEnemyTriggerAnim?.Invoke((TriggerAnimType)anim);
        }
        #endregion

        #region Gameplay Methods

        #endregion

    }
}

