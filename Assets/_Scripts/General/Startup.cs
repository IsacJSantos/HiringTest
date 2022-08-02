using UnityEngine;
using UnityEngine.SceneManagement;
using HiringTest.Utils;

namespace HiringTest 
{
    public class Startup : MonoBehaviour
    {
        void Start()
        {
            SceneManager.LoadScene((int)SceneType.Menu);
        }

    }
}

