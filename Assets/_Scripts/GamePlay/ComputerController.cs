using UnityEngine;
using HiringTest.Utils;

namespace HiringTest 
{
    public class ComputerController : MonoBehaviour, IInteractable
    {
        bool _playerIsInRange;

        #region MonoBehaviour Callbacks
        private void Awake()
        {
           // Events.PlayerInteracted += OnPlayerInteracted;
        }

        private void OnDestroy()
        {
           // Events.PlayerInteracted -= OnPlayerInteracted;
        }

        #endregion

        public void Interact()
        {
            print("Door open successfully");
        }
    }
}

