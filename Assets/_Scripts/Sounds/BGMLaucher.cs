using UnityEngine;

namespace HiringTest 
{
    /*This script is a background music launcher.
     Is put in each scene that needs a bg music*/
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

