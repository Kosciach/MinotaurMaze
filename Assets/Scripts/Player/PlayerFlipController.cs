using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipController : PlayerControllerBase
{
    private void Awake()
    {
        OnAwake();

    }


    public void CheckFlip()
    {
        int xScale = (int)transform.localScale.x;
        if (_playerStateMachine.PlayerControllers.Input.MovementInputVector.x > 0) xScale = 4;
        else if (_playerStateMachine.PlayerControllers.Input.MovementInputVector.x < 0) xScale = -4;
        transform.localScale = new Vector3(xScale, 4, 4);
    }
}
