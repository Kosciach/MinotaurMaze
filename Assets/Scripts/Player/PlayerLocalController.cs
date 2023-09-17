using PlayerStateMachineSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocalController : MonoBehaviour
{
    protected PlayerStateMachine _playerStateMachine;


    protected void OnAwake()
    {
        _playerStateMachine = GetComponent<PlayerStateMachine>();
    }
}
