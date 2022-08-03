using System;

namespace HiringTest.Utils 
{
    public static class Events 
    {
        #region Menus
        public static Action<CanvasType> OpenCanvas;
        public static Action<CanvasType> HideCanvas;
        #endregion

        #region Network
        public static Action Connected;
        public static Action ConnectFail;
        public static Action Disconnected;
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

        public static Action StartGameLoadingScreen;
        #endregion

        #region Enemy
        public static Action<TriggerAnimType> SetEnemyTriggerAnim;
        public static Action<StateType> EnemyInitState;
        #endregion

        #region Player
        public static Action<int> PlayerCaptured;
        #endregion

        #region Gameplay
        public static Action BackToMainMenu;
        #endregion

    }

}

