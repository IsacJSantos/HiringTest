using UnityEngine;
using HiringTest.Utils;

namespace HiringTest
{
    public class PlayerAudioControlller : MonoBehaviour
    {
        [SerializeField] AudioSource _audioSource;
        [SerializeField] AudioClip _screamClip;
        [SerializeField] AudioClip _jumpScareClip;

        PlayerManager _playerManager;
        #region MonoBehaviour Callbacks

        private void Awake()
        {
            Events.PlayerCaptured += OnPlayerCaptured;

            _playerManager = GetComponent<PlayerManager>();
        }

        private void OnDestroy()
        {
            Events.PlayerCaptured -= OnPlayerCaptured;
        }

        #endregion

        void OnPlayerCaptured(int actorNumber)
        {
            if (actorNumber == NetworkManager.Instance.OwnActorNumber) 
            {
                SFXManager.Instance.PlaySFX(_jumpScareClip);
            }

            if (actorNumber == _playerManager.ActorNumber) 
            {
                _audioSource.PlayOneShot(_screamClip);
            }
                
        }
    }
}


