using UnityEngine.InputSystem;
using UnityEngine;

namespace BraveHunterGames
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] int _speed;
        public Input Controls;

        [SerializeField] float _xValue;
        [SerializeField] float _yValue;

        Vector3 _moveDir;
        #region MonoBehaviour Callbacks
        private void Awake()
        {
            Controls = new Input();
            Controls.PlayerControl.Interact.performed += context => Interact();
            Controls.PlayerControl.XMove.performed += context => _xValue = context.ReadValue<Vector2>().x;
            Controls.PlayerControl.YMove.performed += context => _yValue = context.ReadValue<Vector2>().y;
        }

        private void Update()
        {
            transform.Translate(_moveDir * _speed * Time.deltaTime);
        }

        private void OnEnable()
        {
            Controls.Enable();
        }

        private void OnDisable()
        {
            Controls.Disable();
        }

        #endregion

        private void Move(int vect)
        {
            print("Move " + vect);
            //_moveDir = new Vector3(vect.x, 0, vect.y);
        }
        void Interact()
        {
            print("Interact");
        }
    }
}

