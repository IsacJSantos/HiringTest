using UnityEngine.SceneManagement;
using HiringTest.Utils;

namespace HiringTest 
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        #region MonoBehaviour Callbacks
        protected override void Awake()
        {
            base.Awake();
            Events.Disconnected += OnDisconnect;
            Events.BackToMainMenu += OnBackToMainMenu;
        }

        void Start()
        {
            SceneManager.LoadScene((int)SceneType.Menu);
        }

        protected override void OnDestroy()
        {
            Events.Disconnected -= OnDisconnect;
            Events.BackToMainMenu -= OnBackToMainMenu;
            base.OnDestroy();
        }
        #endregion

        void OnDisconnect()
        {
            bool isInGameplayScene = SceneManager.GetActiveScene().buildIndex == (int)SceneType.Gameplay;
            if (isInGameplayScene) 
            {
                SceneManager.LoadScene((int)SceneType.Menu);
            }
        }

        void OnBackToMainMenu() 
        {
            NetworkManager.Instance.LeaveGame();
        }
    }
}

