using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStateMachineSystem
{
    public class PlayerStateMachine : MonoBehaviour
    {
        private PlayerBaseState _currentState; public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
        private PlayerStateFactory _stateFactory; public PlayerStateFactory StateFactory { get { return _stateFactory; } }

        [Header("====StateMachine====")]
        [SerializeField] StateSwitches _stateSwitches;


        [Space(20)]
        [Header("====References====")]
        [SerializeField] PlayerLocalControllers _playerLocalControllers; public PlayerLocalControllers PlayerLocalControllers { get { return _playerLocalControllers; } }



        private void Awake()
        {
            _stateFactory = new PlayerStateFactory(this);

            _stateSwitches = StateSwitches.Main;
            _currentState = _stateFactory.Main();
            _currentState.Enter();
        }
        private void Update()
        {
            _currentState.Update();
            _currentState.CheckStateChange();
        }
        private void FixedUpdate()
        {
            _currentState.FixedUpdate();
        }





        public void SetStateSwitch(StateSwitches stateSwitch)
        {
            _stateSwitches = stateSwitch;
        }
    }

    public enum StateSwitches
    { 
        Main
    }

    [System.Serializable]
    public struct PlayerLocalControllers
    {
        public PlayerInputController Input;
        public PlayerMovementController Movement;
        public PlayerFlashlightController Flashlight;
    }
}