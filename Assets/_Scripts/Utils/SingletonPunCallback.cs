using Photon.Pun;
using UnityEngine;
namespace HiringTest.Utils
{
    public class SingletonPunCallback<T> : MonoBehaviourPunCallbacks
    {
        [SerializeField] bool _dontDestroy;
        public static T Instance => _instance;

        private static T _instance;


        #region MonoBehaviour Callbacks
        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = GetComponent<T>();
                if (_dontDestroy)
                    DontDestroyOnLoad(gameObject);
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

