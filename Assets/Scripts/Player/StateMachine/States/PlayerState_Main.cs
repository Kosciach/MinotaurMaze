using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStateMachineSystem
{
    public class PlayerState_Main : PlayerBaseState
    {
        public PlayerState_Main(PlayerStateMachine ctx, PlayerStateFactory factory) : base(ctx, factory) { }


        public override void Enter()
        {
            
        }
        public override void Update()
        {
            _ctx.Controllers.Flip.CheckFlip();
            _ctx.Controllers.WalkParticle.CheckIfShouldPlay();
            _ctx.Controllers.MinotaurDetector.CheckForMinotaur();
        }
        public override void LateUpdate()
        {
            _ctx.Controllers.Rotation.RotateToMouse();
        }
        public override void FixedUpdate()
        {
            _ctx.Controllers.Movement.Move();
        }
        public override void CheckStateChange()
        {
            if (_ctx.StateSwitch == StateSwitches.GameOver) ChangeState(_factory.GameOver());
        }
        public override void Exit()
        {

        }
    }
}