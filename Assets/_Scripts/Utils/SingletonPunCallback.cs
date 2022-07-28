using Photon.Pun;

namespace BraveHunterGames.Utils
{
    public class SingletonPunCallback<T> : MonoBehaviourPunCallbacks
    {
        public static T Instance => _instance;

        private static T _instance;


        #region MonoBehaviour Callbacks
        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = GetComponent<T>();
            }
            else
                Destroy(gameObject);
        }

        protected virtual void OnDestroy()
        {
            _instance = default;
        }
        #endregion


    }
}

