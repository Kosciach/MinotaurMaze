using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinotaurStateMachineSystem
{
    public class MinotaurState_GameOver : MinotaurBaseState
    {
        public MinotaurState_GameOver(MinotaurStateMachine ctx, MinotaurStateFactory factory) : base(ctx, factory) { }


        public override void Enter()
        {
            _ctx.Animator.SetBool("IsStunned", true);
            _ctx.Controllers.NavMesh.Stop();
        }
        public override void CheckStateChange()
        {

        }
        public override void Exit()
        {

        }
    }
}