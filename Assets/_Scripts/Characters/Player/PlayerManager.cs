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

        [SerializeField] PlayerMovementController _movementController;
        [SerializeField] PlayerInteractController _interactController;

        [SerializeField] Transform _headTransform;
        [SerializeField] Collider _collider;
        [SerializeField] SkinnedMeshRenderer _meshRenderer;
        [SerializeField] Rigidbody _rb;

        PhotonView _photonView;
        int _actorNumber;
        bool _isMine;

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            Events.PlayerLose += OnPlayerLose;
            Events.PlayerEscaped += OnPlayerEscape;

            _photonView = GetComponent<PhotonView>();
            _isMine = _photonView.IsMine;
            _actorNumber = _photonView.OwnerActorNr;
        }

        private void OnDestroy()
        {
            Events.PlayerLose -= OnPlayerLose;
            Events.PlayerEscaped -= OnPlayerEscape;
        }

        #endregion

        public void Init(Transform camTransform)
        {
            _meshRenderer.enabled = false;
            _interactController.Init(camTransform.GetComponent<Camera>());
            _movementController.Init(camTransform);
        }

        void OnPlayerLose(int actorNumber)
        {
            bool isThisPlayer = actorNumber == _actorNumber;

            if (isThisPlayer)
            {
                _rb.isKinematic = true;
                _collider.enabled = false;
            }

        }

        void OnPlayerEscape(int actorNumber)
        {
            bool isThisPlayer = actorNumber == _actorNumber;

            if (isThisPlayer)
            {
                gameObject.SetActive(false);
            }
        }

    }
}

