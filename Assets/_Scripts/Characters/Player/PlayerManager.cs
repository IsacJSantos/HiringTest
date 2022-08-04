using UnityEngine;
using HiringTest.Utils;
using Photon.Pun;

namespace HiringTest 
{
    public class PlayerManager : MonoBehaviour
    {
        public int ActorNumber { get => _actorNumber; }

        public bool IsMine { get => _isMine; }
        public Transform HeadTransform { get => _headTransform; }

        [SerializeField] Transform _headTransform;
        [SerializeField] Collider _collider;
        [SerializeField] SkinnedMeshRenderer _meshRenderer;
        [SerializeField] Rigidbody _rb;

        PhotonView _photonView;
        int _actorNumber;
        bool _isMine;
        bool _isPlaying;
        #region MonoBehaviour Callbacks
        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();

            Events.PlayerLose += OnPlayerLose;

            _isMine = _photonView.IsMine;
            _actorNumber = _photonView.OwnerActorNr;
        }

        private void OnDestroy()
        {
            Events.PlayerLose -= OnPlayerLose;
        }
        private void Update()
        {
            

        }

        #endregion

        void OnPlayerLose(int actorNumber)
        {
            
        }

    }
}

