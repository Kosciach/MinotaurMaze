using Kosciach;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Maze
{
    public class MazeGenerator : MonoBehaviour
    {
        [Header("====Debugs====")]
        [SerializeField] List<MazeRoomRow> _mazeRoomRows; public List<MazeRoomRow> MazeRoomRows { get { return _mazeRoomRows; } }


        [Space(20)]
        [Header("====Settings====")]
        [SerializeField] MazeRoomController _roomPrefab;
        [SerializeField] Vector3 _startingPos;
        [Min(1)]
        [SerializeField] int _width;
        [Min(1)]
        [SerializeField] int _height;



        [System.Serializable]
        public class MazeRoomRow
        {
            public List<MazeRoomController> Rooms;

            public MazeRoomRow()
            {
                Rooms = new List<MazeRoomController>();
            }
        }




        private void Awake()
        {
            CreateRooms();
            CarveTheMaze(null, _mazeRoomRows[0].Rooms[0]);
        }


        private void CreateRooms()
        {
            Vector3 currentPos = _startingPos;
            for (int i=0; i<_height; i++)
            {
                _mazeRoomRows.Add(new MazeRoomRow());
                for (int j=0; j<_width; j++)
                {
                    MazeRoomController newRoom = Instantiate(_roomPrefab, currentPos, Quaternion.identity, transform);
                    newRoom.SetIndexes(i, j);
                    _mazeRoomRows[i].Rooms.Add(newRoom);
                    currentPos.x += 4;
                }
                currentPos.x = _startingPos.x;
                currentPos.y -= 4;
            }
        }

        private void CarveTheMaze(MazeRoomController previousRoom, MazeRoomController currentRoom)
        {
            currentRoom.Visit();
            RemoveRoomsWalls(previousRoom, currentRoom);

            MazeRoomController nextRoom;

            do
            {
                nextRoom = GetNextMazeRoom(currentRoom);

                if(nextRoom != null) CarveTheMaze(currentRoom, nextRoom);
            } while (nextRoom != null);
        }
        private void RemoveRoomsWalls(MazeRoomController previousRoom, MazeRoomController currentRoom)
        {
            if (previousRoom == null) return;

            if(previousRoom.transform.position.x < currentRoom.transform.position.x)//Moved to right
            {
                previousRoom.RemoveWall(MazeRoomWallsEnum.Right);
                currentRoom.RemoveWall(MazeRoomWallsEnum.Left);
                return;
            }
            if (previousRoom.transform.position.x > currentRoom.transform.position.x)//Moved to left
            {
                previousRoom.RemoveWall(MazeRoomWallsEnum.Left);
                currentRoom.RemoveWall(MazeRoomWallsEnum.Right);
                return;
            }
            if (previousRoom.transform.position.y < currentRoom.transform.position.y)//Moved up
            {
                previousRoom.RemoveWall(MazeRoomWallsEnum.Top);
                currentRoom.RemoveWall(MazeRoomWallsEnum.Bottom);
                return;
            }
            if (previousRoom.transform.position.y > currentRoom.transform.position.y)//Moved down
            {
                previousRoom.RemoveWall(MazeRoomWallsEnum.Bottom);
                currentRoom.RemoveWall(MazeRoomWallsEnum.Top);
                return;
            }
        }
        private MazeRoomController GetNextMazeRoom(MazeRoomController currentRoom)
        {
            List<MazeRoomController> unvisitedRooms = new List<MazeRoomController>();

            MazeRoomController roomToCheck;

            //Check room to the right
            if (currentRoom.RoomIndex + 1 < _width)
            {
                roomToCheck = _mazeRoomRows[currentRoom.RowIndex].Rooms[currentRoom.RoomIndex + 1];
                if (!roomToCheck.WasVisited) unvisitedRooms.Add(roomToCheck);
            }

            //Check room to the left
            if (currentRoom.RoomIndex - 1 >= 0)
            {
                roomToCheck = _mazeRoomRows[currentRoom.RowIndex].Rooms[currentRoom.RoomIndex - 1];
                if (!roomToCheck.WasVisited) unvisitedRooms.Add(roomToCheck);
            }

            //Check room above
            if (currentRoom.RowIndex + 1 < _height)
            {
                roomToCheck = _mazeRoomRows[currentRoom.RowIndex + 1].Rooms[currentRoom.RoomIndex];
                if (!roomToCheck.WasVisited) unvisitedRooms.Add(roomToCheck);
            }

            //Check room above
            if (currentRoom.RowIndex - 1 >= 0)
            {
                roomToCheck = _mazeRoomRows[currentRoom.RowIndex - 1].Rooms[currentRoom.RoomIndex];
                if (!roomToCheck.WasVisited) unvisitedRooms.Add(roomToCheck);
            }


            return unvisitedRooms.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
        }
    }
}