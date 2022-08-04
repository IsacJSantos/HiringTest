using UnityEngine;
using HiringTest.Utils;

namespace HiringTest 
{
    public class SFXManager : Singleton<SFXManager>
    {
        [SerializeField] AudioSource _audioSource;

        public void PlaySFX(AudioClip audioClip) 
        {
            _audioSource.PlayOneShot(audioClip);
        }
    }
}


