using UnityEngine;
using HiringTest.Utils;

namespace HiringTest 
{
    public class EscapeLevelTrigger : MonoBehaviour
    {
        #region MonoBehaviour Callbacks
        private void OnTriggerEnter(Collider other)
        {
            PlayerController player;
            if (other.TryGetComponent(out player))
            {
                NetworkManager.Instance.CallPlayerEscapedRPC(player.ActorNumber);
            }
        }

        #endregion


    }
}

