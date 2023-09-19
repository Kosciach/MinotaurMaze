using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavMeshPlus.Components;

public class TestingMinotaurAI : MonoBehaviour
{
    public NavMeshSurface surface;
    public Transform target;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    private void Start()
    {
        surface.BuildNavMesh();
    }
    private void Update()
    {
        navMeshAgent.SetDestination(target.position);
    }
}
