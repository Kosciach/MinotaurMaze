using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers
{
    public class PlayerInputController : PlayerControllerBase
    {
        [Header("====Debugs====")]
        [SerializeField] Camera _camera;


        [Space(20)]
        [Header("====Debugs====")]
        [SerializeField] Vector3 _movementInputVector; public Vector3 MovementInputVector { get { return _movementInputVector; } }
        [SerializeField] Vector3 _mouseWorldPosition; public Vector3 MouseWorldPosition { get { return _mouseWorldPosition; } }


        private PlayerInputs _inputs;



        protected void Awake()
        {
            OnAwake();

            _inputs = new PlayerInputs();
        }
        private void Update()
        {
            SetMovementInputVector();
            SetMouseWorldPosition();
        }


        private void SetMovementInputVector()
        {
            Vector2 movementInputVector = _inputs.Player.Move.ReadValue<Vector2>();
            _movementInputVector = new Vector3(movementInputVector.x, 0, movementInputVector.y);
        }
        private void SetMouseWorldPosition()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -_camera.transform.position.z;
            _mouseWorldPosition = _camera.ScreenToWorldPoint(mousePosition);
        }



        private void OnEnable() => _inputs.Enable();
        private void OnDisable() => _inputs.Disable();
    }
}