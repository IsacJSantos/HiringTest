using UnityEngine.InputSystem;
using UnityEngine;

namespace BraveHunterGames
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Animator _anim;
        [SerializeField] Rigidbody _rb;
        [SerializeField] float _walkSpeed;
        [SerializeField] float _runSpeed;
        [SerializeField] Transform _cameraTransform;


        Transform _transform;
        float _xValue;
        float _yValue;
        bool _isRunning;
        float _blendRunValue;
        float _acceleration = 1.8f;
        InputManager _inputManager;

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        private void Start()
        {
            _inputManager = InputManager.Instance;
        }

        private void Update()
        {
            SetAnimation();
            RotatePlayer();

            if (_inputManager.PlayerInteractThisFrame()) Interact();
            if (_inputManager.PlayerRunThisFrame()) ToggleRun();
            _xValue = _inputManager.GetPlayerMoveX().x;
            _yValue = _inputManager.GetPlayerMoveY().y;
        }

        private void FixedUpdate()
        {
            Move();
        }

        #endregion

        void Move()
        {
            float speed = _isRunning ? _runSpeed : _walkSpeed;
            _rb.velocity = _transform.TransformVector(new Vector3(_xValue, 0, _yValue)).normalized * speed * Time.fixedDeltaTime;
        }

        void RotatePlayer()
        {
            Vector3 newRotation = new Vector3(_transform.eulerAngles.x,_cameraTransform.eulerAngles.y,_transform.eulerAngles.z);
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
        void Interact()
        {
            print("Interact");
        }

        void ToggleRun()
        {
            _isRunning = !_isRunning;
        }
    }
}

