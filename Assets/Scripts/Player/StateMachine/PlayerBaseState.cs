using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStateMachineSystem
{
    public abstract class PlayerBaseState
    {
        protected PlayerStateMachine _ctx;
        protected PlayerStateFactory _factory;


        public PlayerBaseState(PlayerStateMachine ctx, PlayerStateFactory factory)
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


        protected void ChangeState(PlayerBaseState newState)
        {
            _ctx.CurrentState.Exit();
            _ctx.CurrentState = newState;
            _ctx.CurrentState.Enter();
        }
    }
}