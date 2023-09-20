using MinotaurControllers;
using PlayerStateMachineSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MinotaurStateMachineSystem
{
    public class MinotaurStateMachine : MonoBehaviour
    {
        private MinotaurBaseState _currentState; public MinotaurBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
        private MinotaurStateFactory _stateFactory; public MinotaurStateFactory StateFactory { get { return _stateFactory; } }

        [Header("====StateMachine====")]
        [SerializeField] StateSwitches _stateSwitches;


        [Space(20)]
        [Header("====References====")]
        [SerializeField] Animator _animator; public Animator Animator { get { return _animator; } }
        [SerializeField] PlayerStateMachine _playerStateMachine; public PlayerStateMachine PlayerStateMachine { get { return _playerStateMachine; } }
        [SerializeField] Controllers _controllers; public Controllers Controllers { get { return _controllers; } }



        private void Awake()
        {
            _stateFactory = new MinotaurStateFactory(this);

            _stateSwitches = StateSwitches.Chase;
            _currentState = _stateFactory.Chase();
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
            _stateSwitches = stateSwitch;
        }
    }


    public enum StateSwitches
    {
        Chase, Stun
    }

    [System.Serializable]
    public struct Controllers
    {
        public MinotaurNavMeshController NavMesh;
        public MinotaurFlipController Flip;
    }
}