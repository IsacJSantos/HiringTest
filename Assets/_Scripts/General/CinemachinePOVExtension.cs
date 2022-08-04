using UnityEngine;
using Cinemachine;

namespace HiringTest
{
    public class CinemachinePOVExtension : CinemachineExtension
    {
        [SerializeField] float _clampAngle = 80f;
        [SerializeField] float _horizontlSpeed = 10f;
        [SerializeField] float _verticallSpeed = 10f;

        InputManager _inputManager;
        Vector3 _startRotation;

        protected override void Awake()
        {
            base.Awake();
            _inputManager = InputManager.Instance;
        }

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (_inputManager == null) return;
            if (vcam.Follow)
            {
                if (stage == CinemachineCore.Stage.Aim)
                {
                    if (_startRotation == null) _startRotation = transform.localRotation.eulerAngles;
                    Vector2 deltaInput = _inputManager.GetMouseDelta();
                    _startRotation.x += deltaInput.x * _verticallSpeed * Time.deltaTime;
                    _startRotation.y += deltaInput.y * -_horizontlSpeed * Time.deltaTime;
                    _startRotation.y = Mathf.Clamp(_startRotation.y, -_clampAngle, _clampAngle);
                    state.RawOrientation = Quaternion.Euler(_startRotation.y, _startRotation.x, 0f);

                }
            }
        }


    }
}

