using HiringTest.Utils;
using UnityEngine;

namespace HiringTest
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] Animator _anim;
        [SerializeField] Rigidbody _rb;
        [SerializeField] float _walkSpeed;
        [SerializeField] float _runSpeed;
       
        Transform _cameraTransform;
        PlayerManager _playerManager;
        InputManager _inputManager;
        Transform _transform;

        float _xValue;
        float _yValue;
        bool _isRunning;
        float _blendRunValue;
        float _acceleration = 1.8f;

        bool _isPlaying;

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _playerManager = GetComponent<PlayerManager>();
            _inputManager = InputManager.Instance;

            Events.PlayerLose += OnPlayerLose;
        }

        private void OnDestroy()
        {
            Events.PlayerLose -= OnPlayerLose;
        }

        private void Update()
        {
            if (_playerManager.IsMine && _isPlaying)
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
            if (_playerManager.IsMine && _isPlaying)
            {
                Move();
            }

        }

        #endregion


        public void Init(Transform camTransform)
        {
            _cameraTransform = camTransform;
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
            bool isThisPlayer = actorNumber == _playerManager.ActorNumber;
            bool isThisClient = actorNumber == NetworkManager.Instance.OwnActorNumber;


            if (!isThisClient && isThisPlayer) 
            {
                _anim.SetTrigger("death");
            }

        }

    }
}

