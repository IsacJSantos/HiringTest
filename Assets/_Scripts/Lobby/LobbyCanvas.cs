using BraveHunterGames.Utils;
using TMPro;
using UnityEngine;

namespace BraveHunterGames 
{
    public class LobbyCanvas : MonoBehaviour
    {
       [SerializeField] Canvas _canvas;
        
        bool _isReady;

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            Events.Connected += OnConnect;
        }
        private void Start()
        {
            _canvas.enabled = false;
        }
        private void OnDestroy()
        {
            Events.Connected -= OnConnect;
        }

        #endregion

        public void StartGame() 
        {
            Events.StartGame?.Invoke();
        }

        public void Ready() 
        {
            _isReady = !_isReady;
        }

        public void LeaveRoom() 
        {
            Events.Logout?.Invoke();
            _canvas.enabled = false;
        }

        void OnConnect() 
        {
            _canvas.enabled = true;
        }
    }

}

