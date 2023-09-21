using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementController : PlayerControllerBase
    {
        [Header("====Settings====")]
        [Range(0, 50)]
        [SerializeField] float _speed = 0;
        [Range(0, 50)]
        [SerializeField] float _smoothTime = 0;


        private Rigidbody2D _rigidbody;
        private Vector3 _currentMovement = Vector3.zero; public Vector3 CurrentMovement { get { return _currentMovement; } }
        private Vector3 _currentVelocityRef = Vector3.zero;


        protected new void Awake()
        {
            base.Awake();

            _rigidbody = GetComponent<Rigidbody2D>();
        }




        public void Move()
        {
            Vector3 inputVector = _playerStateMachine.Controllers.Input.MovementInputVector;
            Vector3 targetedMovement = (Vector3.right * inputVector.x + Vector3.up * inputVector.z) * _speed * 10 * Time.deltaTime;
            _currentMovement = Vector3.SmoothDamp(_currentMovement, targetedMovement, ref _currentVelocityRef, _smoothTime * 10 * Time.deltaTime);
            _rigidbody.velocity = _currentMovement;

            SetPlayerAnimation();
        }
        private void SetPlayerAnimation()
        {
            _playerStateMachine.Animator.SetFloat("PlayerVelocity", _playerStateMachine.Controllers.Input.MovementInputVector.magnitude);
        }


        public void Stop()
        {
            _currentMovement = Vector3.zero;
            _currentVelocityRef = Vector3.zero;
            _rigidbody.velocity = Vector3.zero;
        }
    }
}