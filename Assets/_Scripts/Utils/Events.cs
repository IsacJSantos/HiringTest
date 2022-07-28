using Photon.Pun;
using Photon.Realtime;

namespace BraveHunterGames.Utils 
{
    public static class Events 
    {
        #region Network
        public static SimpleEvent Connected;
        public static IntStringEvent PlayerLeftRoom;
        public static IntStringEvent PlayerEnterRoom;
        #endregion

        #region Lobby
        public static SimpleEvent Login;
        public static SimpleEvent StartGame;
        public static SimpleEvent Logout;
        #endregion



        public delegate void SimpleEvent();
        public delegate void IntEvent(int i);
        public delegate void IntStringEvent(int i, string s);
        public delegate void PunPlayerEvent(Player p);
    }
   
}

