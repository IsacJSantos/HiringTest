using Photon.Pun;
using Photon.Realtime;

namespace BraveHunterGames.Utils 
{
    public static class Events 
    {
        #region Menus
        public static MenuTypeEvent OpenMenu;
        public static MenuTypeEvent HideMenu;
        #endregion

        #region Network
        public static SimpleEvent Connected;
        public static IntStringEvent PlayerLeftRoom;
        public static IntStringEvent PlayerEnterRoom;

        public static IntBoolEvent SetPlayerReady;
        public static IntBoolEvent PlayerReady;
        #endregion

        #region Lobby
        public static SimpleEvent Login;
        public static SimpleEvent StartGame;
        public static SimpleEvent Logout;

        public static BoolEvent AllPlayersReady;
        #endregion



        public delegate void SimpleEvent();
        public delegate void IntEvent(int i);
        public delegate void BoolEvent(bool b);
        public delegate void IntStringEvent(int i, string s);
        public delegate void IntBoolEvent(int i, bool b);
        public delegate void PunPlayerEvent(Player p);
        public delegate void MenuTypeEvent(MenuType mt);
    }
   
}

