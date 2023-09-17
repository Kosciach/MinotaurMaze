using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : PlayerControllerBase
{
    private PlayerInputs _inputs;

    [Header("====Debugs====")]
    [SerializeField] Vector3 _movementInputVector; public Vector3 MovementInputVector { get { return _movementInputVector; } }



    protected void Awake()
    {
        OnAwake();

        _inputs = new PlayerInputs();
    }
    private void Update()
    {
        SetMovementInputVector();
    }


    private void SetMovementInputVector()
    {
        Vector2 movementInputVector = _inputs.Player.Move.ReadValue<Vector2>();
        _movementInputVector = new Vector3(movementInputVector.x, 0, movementInputVector.y);
    }



    private void OnEnable() => _inputs.Enable();
    private void OnDisable() => _inputs.Disable();
}