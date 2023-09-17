using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStateMachineSystem
{
    public class PlayerStateFactory
    {
        private PlayerStateMachine _playerStateMachine;

        public PlayerStateFactory(PlayerStateMachine playerStateMachine)
        {
            _playerStateMachine = playerStateMachine;
        }



        public PlayerBaseState Main()
        {
            return new PlayerState_Main(_playerStateMachine, this);
        }
    }
}