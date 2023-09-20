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
        }
        public override void CheckStateChange()
        {

        }
        public override void Exit()
        {
            _ctx.Animator.SetBool("IsStunned", false);
        }
    }
}