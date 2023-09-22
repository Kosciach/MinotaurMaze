using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinotaurStateMachineSystem
{
    public class MinotaurState_Chase : MinotaurBaseState
    {
        public MinotaurState_Chase(MinotaurStateMachine ctx, MinotaurStateFactory factory) : base(ctx, factory) { }


        public override void Enter()
        {

        }
        public override void Update()
        {
            _ctx.Controllers.NavMesh.ChasePlayer();
            _ctx.Controllers.Flip.CheckFlip();
        }
        public override void CheckStateChange()
        {
            if (_ctx.StateSwitch == StateSwitches.GameOver) ChangeState(_factory.GameOver());
            else if (_ctx.StateSwitch == StateSwitches.Stun) ChangeState(_factory.Stun());
        }
        public override void Exit()
        {

        }
    }
}