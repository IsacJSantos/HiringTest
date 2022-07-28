using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using BraveHunterGames.Utils;

namespace BraveHunterGames 
{
    public class NetworkManager : SingletonPunCallback<NetworkManager>
    {
        public Player[] PlayerList
        {
            get
            {
                if (PhotonNetwork.InRoom)
                    return PhotonNetwork.PlayerList;
                else
                    return null;
            }
        }

        #region Photon Callbacks
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Events.PlayerEnterRoom?.Invoke(newPlayer.ActorNumber, newPlayer.NickName);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            Events.PlayerLeftRoom?.Invoke(otherPlayer.ActorNumber, otherPlayer.NickName);
        }
        #endregion



    }
}

