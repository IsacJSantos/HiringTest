using UnityEngine;
using HiringTest.Utils;

namespace HiringTest 
{
    public class SFXManager : Singleton<SFXManager>
    {
        [SerializeField] AudioSource _audioSource;

        #region MonoBehavior Callbacks
       
        #endregion

        public void PlaySFX(AudioClip audioClip) 
        {
            _audioSource.PlayOneShot(audioClip);
        }
    }
}


