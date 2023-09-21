using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerControllers;
using PlayerControllers.AbilitiesSystem;
using MinotaurStateMachineSystem;

namespace PlayerStateMachineSystem
{
    public class PlayerStateMachine : MonoBehaviour
    {
        private PlayerBaseState _currentState; public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
        private PlayerStateFactory _stateFactory; public PlayerStateFactory StateFactory { get { return _stateFactory; } }

        [Header("====StateMachine====")]
        [SerializeField] StateSwitches _stateSwitch; public StateSwitches StateSwitch { get { return _stateSwitch; } }


        [Space(20)]
        [Header("====References====")]
        [SerializeField] Animator _animator; public Animator Animator { get { return _animator; } }
        [SerializeField] MinotaurStateMachine _minotaurStateMachine; public MinotaurStateMachine MinotaurStateMachine { get { return _minotaurStateMachine; } }
        [SerializeField] Controllers _controllers; public Controllers Controllers { get { return _controllers; } }



        private void Awake()
        {
            _stateFactory = new PlayerStateFactory(this);

            _stateSwitch = StateSwitches.Main;
            _currentState = _stateFactory.Main();
            _currentState.Enter();
        }
        private void Update()
        {
            _currentState.Update();
            _currentState.CheckStateChange();
        }
        private void LateUpdate()
        {
            _currentState.LateUpdate();
        }
        private void FixedUpdate()
        {
            _currentState.FixedUpdate();
        }





        public void SetStateSwitch(StateSwitches stateSwitch)
        {
            _stateSwitch = stateSwitch;
        }
    }

    public enum StateSwitches
    { 
        Main, GameOver
    }

    [System.Serializable]
    public struct Controllers
    {
        public PlayerInputController Input;
        public PlayerMovementController Movement;
        public PlayerFlashlightController Flashlight;
        public PlayerRotationController Rotation;
        public PlayerFlipController Flip;
        public PlayerMinotaurDetector MinotaurDetector;
        public PlayerWalkParticleController WalkParticle;
        public PlayerAbilitiesController Abilities;
    }
}