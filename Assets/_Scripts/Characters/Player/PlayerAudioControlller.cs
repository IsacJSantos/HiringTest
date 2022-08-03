using UnityEngine;
using HiringTest.Utils;

namespace HiringTest
{
    public class PlayerAudioControlller : MonoBehaviour
    {
        [SerializeField] AudioSource _audioSource;
        [SerializeField] AudioClip _screamClip;
        [SerializeField] AudioClip _jumpScareClip;

        PlayerController _playerController;
        #region MonoBehaviour Callbacks

        private void Awake()
        {
            Events.PlayerCaptured += OnPlayerCaptured;
            _playerController = GetComponent<PlayerController>();
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

            if (actorNumber == _playerController.ActorNumber) 
            {
                _audioSource.PlayOneShot(_screamClip);
            }
                
        }
    }
}


