using HiringTest.Utils;
using Photon.Pun;
using UnityEngine;

namespace HiringTest
{
    public class PlayerController : MonoBehaviour
    {
        public int ActorNumber { get => _actorNumber; }

        public bool IsMine { get => _isMine; }
        public Transform HeadTransform { get => _headTransform; }

        [SerializeField] Animator _anim;
        [SerializeField] Rigidbody _rb;
        [SerializeField] float _walkSpeed;
        [SerializeField] float _runSpeed;
        [SerializeField] Transform _cameraTransform;
        [SerializeField] Transform _headTransform;
        [SerializeField] Collider _collider;
        [SerializeField] SkinnedMeshRenderer _meshRenderer;

        [SerializeField] PlayerInteractController _interactController;

        int _actorNumber;
        bool _isMine;
        float _xValue;
        float _yValue;
        bool _isRunning;
        float _blendRunValue;
        float _acceleration = 1.8f;
        InputManager _inputManager;
        Transform _transform;
        PhotonView _photonView;
        bool _isPlaying;

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _photonView = GetComponent<PhotonView>();
            _inputManager = InputManager.Instance;

            Events.PlayerLose += OnPlayerLose;
            Events.PlayerEscaped += OnPlayerEscape;

            _isMine = _photonView.IsMine;
            _actorNumber = _photonView.OwnerActorNr;
        }

        private void OnDestroy()
        {
            Events.PlayerLose -= OnPlayerLose;
            Events.PlayerEscaped += OnPlayerEscape;
        }

        private void Update()
        {
            if (_photonView.IsMine && _isPlaying)
            {
                SetAnimation();
                RotatePlayer();

                if (_inputManager.PlayerRunThisFrame()) ToggleRun();
                _xValue = _inputManager.GetPlayerMoveX().x;
                _yValue = _inputManager.GetPlayerMoveY().y;
            }


        }

        private void FixedUpdate()
        {
            if (_photonView.IsMine && _isPlaying)
            {
                Move();
            }

        }

        #endregion


        public void Init(Transform camTransform, int actorNumber)
        {
            _meshRenderer.enabled = false;
            _cameraTransform = camTransform;
            _interactController.Init(_cameraTransform.GetComponent<Camera>());
            _isPlaying = true;
        }

        void Move()
        {
            float speed = _isRunning ? _runSpeed : _walkSpeed;
            _rb.velocity = _transform.TransformVector(new Vector3(_xValue, 0, _yValue)).normalized * speed * Time.fixedDeltaTime;
        }

        void RotatePlayer()
        {
            Vector3 newRotation = new Vector3(_transform.eulerAngles.x, _cameraTransform.eulerAngles.y, _transform.eulerAngles.z);
            _transform.eulerAngles = newRotation;
        }

        private void SetAnimation()
        {
            _anim.SetInteger("vertical", (int)_yValue);
            _anim.SetInteger("horizontal", (int)_xValue);
            _anim.SetFloat("blendRun", _blendRunValue);

            if (_isRunning)
            {
                if (_blendRunValue < 1)
                    _blendRunValue += _acceleration * Time.deltaTime;
                else
                    _blendRunValue = 1;
            }
            else
            {
                if (_blendRunValue > 0)
                    _blendRunValue -= _acceleration * Time.deltaTime;
                else
                    _blendRunValue = 0;
            }
        }

        void ToggleRun()
        {
            _isRunning = !_isRunning;
        }

        void OnPlayerLose(int actorNumber)
        {
            bool isThisPlayer = actorNumber == _actorNumber;
            bool isThisClient = actorNumber == NetworkManager.Instance.OwnActorNumber;

            if (isThisPlayer) 
            {
                _rb.isKinematic = true;
                _collider.enabled = false;

                if(!isThisClient)
                    _anim.SetTrigger("death");

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

