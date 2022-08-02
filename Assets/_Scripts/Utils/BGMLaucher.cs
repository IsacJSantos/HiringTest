using UnityEngine;

namespace HiringTest 
{
    public class BGMLaucher : MonoBehaviour
    {
        [SerializeField] AudioClip _musicClip;

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            BGMManager.Instance.PlayMusic(_musicClip);
        }
        #endregion
    }
}

