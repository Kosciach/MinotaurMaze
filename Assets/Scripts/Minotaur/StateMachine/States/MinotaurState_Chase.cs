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
        }
        public override void CheckStateChange()
        {

        }
        public override void Exit()
        {

        }
    }
}