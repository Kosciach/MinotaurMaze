using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinotaurStateMachineSystem
{
    public class MinotaurState_Stun : MinotaurBaseState
    {
        public MinotaurState_Stun(MinotaurStateMachine ctx, MinotaurStateFactory factory) : base(ctx, factory) { }


        public override void Enter()
        {
            _ctx.Animator.SetBool("IsStunned", true);
            _ctx.Controllers.NavMesh.Stop();
        }
        public override void CheckStateChange()
        {
            if (_ctx.StateSwitch == StateSwitches.GameOver) ChangeState(_factory.GameOver());
            else if (_ctx.StateSwitch == StateSwitches.Chase) ChangeState(_factory.Chase());
        }
        public override void Exit()
        {
            _ctx.Animator.SetBool("IsStunned", false);
        }
    }
}