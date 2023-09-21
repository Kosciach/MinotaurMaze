using Maze;
using PlayerStateMachineSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] MazeGenerator _mazeGenerator;
    [SerializeField] PlayerStateMachine _playerStateMachine;


    private void Start()
    {
        Vector3 portalPos = Vector3.zero;
        do
        {
            int randomRowIndex = UnityEngine.Random.Range(0, _mazeGenerator.MazeRoomRows.Count);
            int randomRoomIndex = UnityEngine.Random.Range(0, _mazeGenerator.MazeRoomRows[0].Rooms.Count);
            portalPos = _mazeGenerator.MazeRoomRows[randomRowIndex].Rooms[randomRoomIndex].transform.position;
        } while (portalPos.x == -18 || portalPos.y == -18);

        portalPos.z = -0.01f;
        transform.position = portalPos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        _playerStateMachine.SetStateSwitch(PlayerStateMachineSystem.StateSwitches.GameOver);
        _playerStateMachine.MinotaurStateMachine.SetStateSwitch(MinotaurStateMachineSystem.StateSwitches.GameOver);
        SceneFaderController.Instance.FadeAndChangeScene("PlayerWinScene");
    }
}
