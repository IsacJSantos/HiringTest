using UnityEngine;
using HiringTest.Utils;
using DG.Tweening;
using System;

namespace HiringTest
{
    public class BGMManager : Singleton<BGMManager>
    {
        [SerializeField] AudioSource _audioSource;
        [SerializeField] float _transitionDelay = 0.4f;

        float _volume;

        #region MonoBahaviour callbacks
        protected override void Awake()
        {
            base.Awake();
            _volume = _audioSource.volume;
        }

        #endregion

        public void PlayMusic(AudioClip audioClip)
        {
            ToogleAudioClip(false, () =>
             {
                 _audioSource.clip = audioClip;
                 _audioSource.Play();
                 ToogleAudioClip(true);
             });
        }

        public void StopMusic()
        {
            ToogleAudioClip(false, () => { _audioSource.Stop(); });
        }

        void ToogleAudioClip(bool play, Action callback = null)
        {
            float targetVolume = play ? _volume : 0;
            _audioSource.DOFade(targetVolume, _transitionDelay).OnComplete(() =>
             {
                 callback?.Invoke();
             });
        }
    }
}

