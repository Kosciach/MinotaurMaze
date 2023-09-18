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
            _ctx.PlayerControllers.Flip.CheckFlip();
        }
        public override void LateUpdate()
        {
            _ctx.PlayerControllers.Rotation.RotateToMouse();
        }
        public override void FixedUpdate()
        {
            _ctx.PlayerControllers.Movement.Move();
        }
        public override void CheckStateChange()
        {

        }
        public override void Exit()
        {

        }
    }
}