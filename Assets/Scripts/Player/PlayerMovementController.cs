using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : PlayerLocalController
{
    [Header("====Settings====")]
    [Range(0, 10)]
    [SerializeField] float _speed = 0;
    [Range(0, 10)]
    [SerializeField] float _smoothTime = 0;


    private Rigidbody2D _rigidbody;
    private Vector3 _currentMovement = Vector3.zero;
    private Vector3 _currentVelocityRef = Vector3.zero;


    protected void Awake()
    {
        base.OnAwake();

        _rigidbody = GetComponent<Rigidbody2D>();
    }




    public void Move()
    {
        Vector3 inputVector = _playerStateMachine.PlayerLocalControllers.Input.MovementInputVector;
        Vector3 targetedMovement = (Vector3.right * inputVector.x + Vector3.up * inputVector.z) * _speed;
        _currentMovement = Vector3.SmoothDamp(_currentMovement, targetedMovement, ref _currentVelocityRef, _smoothTime);
        _rigidbody.velocity = _currentMovement;
    }

}
