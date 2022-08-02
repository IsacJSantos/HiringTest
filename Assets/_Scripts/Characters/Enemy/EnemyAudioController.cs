using UnityEngine;
using HiringTest.Utils;

namespace HiringTest
{
    public class EnemyAudioController : MonoBehaviour
    {
        [SerializeField] AudioSource _audioSource;
        [SerializeField] AudioClip _breathingClip;
        [SerializeField] AudioClip _screenClip;

        bool _isChasingPlayer;
        #region MonoBehaviour Callbacks
        private void Awake()
        {
            Events.EnemyInitState += OnEnemyInitState;
        }

        private void OnDestroy()
        {
            Events.EnemyInitState -= OnEnemyInitState;
        }

        #endregion

        void OnEnemyInitState(StateType state) 
        {
            switch (state)
            {
                case StateType.IDLE:
                    InitBreathingSFX();
                    break;
                case StateType.PATROL:
                    InitBreathingSFX();
                    break;
                case StateType.PURSUE:
                    InitScreenSFX();
                    break;
                default:
                    break;
            }
        }


        void InitBreathingSFX()
        {
            if (_isChasingPlayer)
            {
                _isChasingPlayer = false;
                _audioSource.Stop();
                _audioSource.clip = _breathingClip;
                _audioSource.loop = true;
                _audioSource.Play();
            }
        }

        void InitScreenSFX()
        {
            if (!_isChasingPlayer)
            {
                _isChasingPlayer = true;

                _audioSource.Stop();
                _audioSource.clip = _screenClip;
                _audioSource.loop = false;
                _audioSource.Play();
            }

        }
    }
}

