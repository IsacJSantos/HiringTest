using BraveHunterGames.Utils;
using UnityEngine;
using TMPro;

namespace BraveHunterGames
{
    public class PlayerPanelEntry : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _nickNameText;
        [SerializeField] TextMeshProUGUI _readyText;

        [SerializeField] int _playerNumber;

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            // Events.PlayerEnterRoom += OnPlayerEnter;
            Events.PlayerLeftRoom += OnPlayerLeft;
        }

        private void OnDestroy()
        {
            // Events.PlayerEnterRoom -= OnPlayerEnter;
            Events.PlayerLeftRoom -= OnPlayerLeft;
        }
        #endregion

        public void Init(int actorNumber, string nickName) 
        {
            _nickNameText.text = nickName;
            _playerNumber = actorNumber;
        }

        /*
        void OnPlayerEnter(int actorNumber) 
        {

        }
        */

        void OnPlayerLeft(int actorNumber, string nickName)
        {
            if (actorNumber == _playerNumber)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

