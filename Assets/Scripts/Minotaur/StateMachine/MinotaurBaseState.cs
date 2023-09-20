using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinotaurStateMachineSystem
{
    public abstract class MinotaurBaseState
    {
        protected MinotaurStateMachine _ctx;
        protected MinotaurStateFactory _factory;


        public MinotaurBaseState(MinotaurStateMachine ctx, MinotaurStateFactory factory)
        {
            _ctx = ctx;
            _factory = factory;
        }


        public abstract void Enter();
        public virtual void Update() { }
        public virtual void LateUpdate() { }
        public virtual void FixedUpdate() { }
        public abstract void CheckStateChange();
        public abstract void Exit();


        protected void StateChange(MinotaurBaseState newState)
        {
            _ctx.CurrentState.Exit();
            _ctx.CurrentState = newState;
            _ctx.CurrentState.Enter();
        }
    }
}