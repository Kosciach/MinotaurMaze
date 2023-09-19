using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class MazeRoomController : MonoBehaviour
    {
        [Header("====References====")]
        [SerializeField] MazeRoomWalls _walls;      public MazeRoomWalls Walls { get { return _walls; } }
        [SerializeField] bool _wasVisited;          public bool WasVisited { get { return _wasVisited; } }
        [SerializeField] int _rowIndex;             public int RowIndex { get { return _rowIndex; } }
        [SerializeField] int _roomIndex;            public int RoomIndex { get { return _roomIndex; } }


        public void RemoveWall(MazeRoomWallsEnum mazeRoomWall)
        {
            switch(mazeRoomWall)
            {
                case MazeRoomWallsEnum.Left:    _walls.Left.SetActive(false); break;
                case MazeRoomWallsEnum.Top:     _walls.Top.SetActive(false); break;
                case MazeRoomWallsEnum.Right:   _walls.Right.SetActive(false); break;
                case MazeRoomWallsEnum.Bottom:  _walls.Bottom.SetActive(false); break;
                case MazeRoomWallsEnum.Roof:    _walls.Roof.SetActive(false); break;
            }
        }
        public void Visit()
        {
            _wasVisited = true;
            RemoveWall(MazeRoomWallsEnum.Roof);
        }
        public void SetIndexes(int rowIndex, int roomIndex)
        {
            _rowIndex = rowIndex;
            _roomIndex = roomIndex;
        }
    }


    [System.Serializable]
    public struct MazeRoomWalls
    {
        public GameObject Left;
        public GameObject Top;
        public GameObject Right;
        public GameObject Bottom;
        public GameObject Roof;
    }

    public enum MazeRoomWallsEnum
    { 
        Left, Top, Right, Bottom, Roof
    }
}