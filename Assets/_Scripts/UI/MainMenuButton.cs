using UnityEngine;
using HiringTest.Utils;

namespace HiringTest
{
    public class MainMenuButton : MonoBehaviour
    {
        public void BackToMainMenu() 
        {
            Events.BackToMainMenu?.Invoke();
        }
    }
}

