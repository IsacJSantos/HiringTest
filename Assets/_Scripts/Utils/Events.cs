using System;

namespace BraveHunterGames.Utils 
{
    public static class Events 
    {
        #region Menus
        public static Action<MenuType> OpenMenu;
        public static Action<MenuType> HideMenu;
        #endregion

        #region Network
        public static Action Connected;
        public static Action ConnectFail;
        public static Action<int, string> PlayerLeftRoom;
        public static Action<int, string> PlayerEnterRoom;

        public static Action<int, bool> SetPlayerReady;
        public static Action<int, bool> PlayerReady;

        #endregion

        #region Lobby
        public static Action InitLogin;
        public static Action StartGame;
        public static Action Logout;

        public static Action<bool> AllPlayersReady;
        #endregion

        #region Enemy
        public static Action<TriggerAnimType> SetEnemyTriggerAnim;
        #endregion

    }
   
}

