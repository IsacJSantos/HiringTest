
namespace BraveHunterGames.Utils 
{
    public static class Events 
    {
        #region Network
        public static SimpleEvent Connected;
        #endregion

        #region Lobby
        public static SimpleEvent Login;
        public static SimpleEvent StartGame;
        public static SimpleEvent Logout;
        #endregion



        public delegate void SimpleEvent();
    }
   
}

