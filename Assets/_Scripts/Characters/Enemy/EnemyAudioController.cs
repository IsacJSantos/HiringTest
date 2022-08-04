using UnityEngine;
using HiringTest.Utils;
using System.Collections;
namespace HiringTest
{
    public class EnemyAudioController : MonoBehaviour
    {
        [SerializeField] AudioSource _audioSource;
        [SerializeField] AudioClip[] _breathingClips;
        [SerializeField] AudioClip _screamClip;

        float _breathDelay = 6f;
        bool _isChasingPlayer;
        Coroutine _breathingRoutine;

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            Events.EnemyInitState += OnEnemyInitState;
        }

        private void Start()
        {
            _breathingRoutine = StartCoroutine(_Breathing());
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
            if (!_isChasingPlayer) return;

            _isChasingPlayer = false;

            if (_breathingRoutine != null)
                StopCoroutine(_breathingRoutine);

            _breathingRoutine = StartCoroutine(_Breathing());

        }

        void InitScreenSFX()
        {
            if (!_isChasingPlayer)
            {
                _isChasingPlayer = true;

                if (_breathingRoutine != null)
                    StopCoroutine(_breathingRoutine);

                _audioSource.Stop();
                _audioSource.PlayOneShot(_screamClip);
            }

        }

        IEnumerator _Breathing() // Plays random breath sound
        {
            while (true)
            {
                int index = Random.Range(0, _breathingClips.Length);
                _audioSource.Stop();
                _audioSource.PlayOneShot(_breathingClips[index]);
                yield return new WaitForSeconds(_breathDelay);
            }
           
        }
    }
}

