using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] NavMeshSurface _navMeshSurface;


    private void Start()
    {
        //Build NavMesh after maze is generated(it generates on Awake)
        _navMeshSurface.BuildNavMesh();
    }
}
