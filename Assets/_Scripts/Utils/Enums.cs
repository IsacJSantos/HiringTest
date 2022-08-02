
namespace HiringTest.Utils
{

    #region General

    [System.Serializable]
    public enum CanvasType { Lobby, Login, Pause, Connecting, Victory, Lose };


    [System.Serializable]
    public enum SceneType { Menu = 1, Gameplay };

    #endregion

    #region Enemy

    [System.Serializable]
    public enum TriggerAnimType { Idle, Walk, Run, Attack };

    #endregion

    #region StatePattern

    [System.Serializable]
    public enum StateType
    {
        IDLE, PATROL, PURSUE, ATTACK
    }

    [System.Serializable]
    public enum StateEventType
    {
        ENTER, UPDATE, EXIT
    }

    #endregion


}
