using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStateMachineSystem
{
    public class PlayerState_GameOver : PlayerBaseState
    {
        public PlayerState_GameOver(PlayerStateMachine ctx, PlayerStateFactory factory) : base(ctx, factory) { }


        public override void Enter()
        {
            _ctx.Controllers.Movement.Stop();
        }
        public override void CheckStateChange()
        {

        }
        public override void Exit()
        {

        }
    }
}