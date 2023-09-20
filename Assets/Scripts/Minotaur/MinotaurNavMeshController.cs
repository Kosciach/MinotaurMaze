using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MinotaurControllers
{
    public class MinotaurNavMeshController : MinotaurControllerBase
    {
        [Header("====References====")]
        [SerializeField] NavMeshAgent _navMeshAgent;


        private void Awake()
        {
            OnAwake();

            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;
        }


        public void ChasePlayer()
        {
            _navMeshAgent.SetDestination(_minotaurStateMachine.PlayerStateMachine.transform.position);
        }
        public void Stop()
        {
            _navMeshAgent.SetDestination(transform.position);
        }
    }
}