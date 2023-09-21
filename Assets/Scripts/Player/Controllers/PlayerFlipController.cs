using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers
{
    public class PlayerFlipController : PlayerControllerBase
    {
        public void CheckFlip()
        {
            int xScale = (int)transform.localScale.x;
            if (_playerStateMachine.Controllers.Input.MovementInputVector.x > 0) xScale = 4;
            else if (_playerStateMachine.Controllers.Input.MovementInputVector.x < 0) xScale = -4;
            transform.localScale = new Vector3(xScale, 4, 4);
        }
    }
}