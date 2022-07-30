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

        int _xValue;
        int _yValue;
        bool _isRunning;
        Input _controls;

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            _controls = new Input();
            _controls.PlayerControl.Interact.performed += context => Interact();
            _controls.PlayerControl.XMove.performed += context => _xValue = (int)context.ReadValue<Vector2>().x;
            _controls.PlayerControl.YMove.performed += context => _yValue = (int)context.ReadValue<Vector2>().y;
            _controls.PlayerControl.Run.performed += context => ToggleRun();
        }

        private void Update()
        {
            SetAnimation();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        #endregion

        void Move()
        {
            float speed = _isRunning ? _runSpeed : _walkSpeed;
            _rb.velocity = new Vector3(_xValue, 0, _yValue) * speed * Time.fixedDeltaTime;
        }
        private void SetAnimation()
        {
            _anim.SetInteger("vertical", _yValue);
            _anim.SetInteger("horizontal", _xValue);
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

