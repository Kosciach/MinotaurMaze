using MinotaurControllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurCollisionController : MinotaurControllerBase
{
    private void Awake()
    {
        OnAwake();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        _minotaurStateMachine.PlayerStateMachine.SetStateSwitch(PlayerStateMachineSystem.StateSwitches.GameOver);
        _minotaurStateMachine.SetStateSwitch(MinotaurStateMachineSystem.StateSwitches.GameOver);
        SceneFaderController.Instance.FadeAndChangeScene("MinotaurWinScene");
    }
}
