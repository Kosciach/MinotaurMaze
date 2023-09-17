using PlayerStateMachineSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBase : MonoBehaviour
{
    protected PlayerStateMachine _playerStateMachine;


    protected void OnAwake()
    {
        _playerStateMachine = transform.root.GetComponent<PlayerStateMachine>();
    }
}
