using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinotaurStateMachineSystem
{
    public class MinotaurStateFactory
    {
        private MinotaurStateMachine _minotaurStateMachine;

        public MinotaurStateFactory(MinotaurStateMachine minotaurStateMachine)
        {
            _minotaurStateMachine = minotaurStateMachine;
        }



        public MinotaurBaseState Chase()
        {
            return new MinotaurState_Chase(_minotaurStateMachine, this);
        }
        public MinotaurBaseState Stun()
        {
            return new MinotaurState_Stun(_minotaurStateMachine, this);
        }
        public MinotaurBaseState GameOver()
        {
            return new MinotaurState_GameOver(_minotaurStateMachine, this);
        }
    }
}