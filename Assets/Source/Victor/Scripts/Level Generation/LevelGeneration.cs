using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class LevelGeneration : MonoBehaviour
{
    [Header("Level Generation")]
    [SerializeField] private MapRoomSelector generator;
    [SerializeField] private int numberOfRooms = 20;
    [SerializeField] private Vector2 worldSize = new Vector2(4, 4);
    [SerializeField] private GameObject playerSpawn;
    [SerializeField] private GameObject exitDoor;
    [SerializeField] private CameraMove cam;

    [Header("Navmesh Config")]
    [SerializeField] private bool demoMode;
    [SerializeField] private AstarPath aStarPath;



    private StandardRoom[,] rooms;
    private List<Vector2> takenPos = new List<Vector2>();
    private int gridSizeX, gridSizeY;
    private Vector2 startRoomPos;


    private void Start()
    {
        if (numberOfRooms >= (worldSize.x * 2) * (worldSize.y * 2))
        {
            numberOfRooms = Mathf.RoundToInt((worldSize.x * 2) * (worldSize.y * 2));
        }

        gridSizeX = Mathf.RoundToInt(worldSize.x);
        gridSizeY = Mathf.RoundToInt(worldSize.y);

        CreateRooms();

        SetRoomDoors();

        DrawMap();

        if (demoMode)
        {
            aStarPath.Scan();
        }
    }

    void DrawMap()
    {
        foreach (StandardRoom room in rooms)
        {
            if (room == null)
            {
                continue;
            }

            Vector2 drawPos = room.gridPos;
            drawPos.x *= 48;
            drawPos.y *= 27;

            room.SetRoom( generator.GenerateRoom(drawPos, room.Doors()), exitDoor, playerSpawn);
        }

        cam.FindPlayer();
    }

    void CreateRooms()
    {
        rooms = new StandardRoom[gridSizeX * 2, gridSizeY * 2];
        Vector2Int start = new Vector2Int(0, 0);
        rooms[start.x + gridSizeX, start.y + gridSizeY] = new StandardRoom(new Vector2(start.x, start.y));
        takenPos.Insert(0, new Vector2(start.x, start.y));
        Vector2 checkPos = new Vector2(start.x, start.y);

        float randomCompare = .1f;
        float randomCompareStart = .1f;
        float randomCompareEnd = .01f;

        for (int i = 0; i < numberOfRooms - 1; i++)
        {
            float randomPercent = ((float)i) / (((float)numberOfRooms - 1));
            randomCompare = Mathf.Lerp(randomCompareStart, randomCompareEnd, randomPercent);

            checkPos = NewPos();

            if ( (NumberOfNeighbors(checkPos, takenPos) > 1) && (Random.value > randomCompare) )
            {
                int iterations = 0;
                do
                {
                    checkPos = SelectiveNewPos();
                    iterations++;
                } 
                while ((NumberOfNeighbors(checkPos, takenPos) > 1) && (iterations < 100));

                if (iterations >= 50)
                {
                    print("Error: Could not create with fewer neighbors than: " + NumberOfNeighbors(checkPos, takenPos));
                }
            }

            rooms[(int)checkPos.x + gridSizeX, (int)checkPos.y + gridSizeY] = new StandardRoom(checkPos);
            takenPos.Insert(0, checkPos);
        }


        int leftMost = gridSizeX;
        int rightMost = -gridSizeX;
        int upMost = -gridSizeY;
        int downMost = gridSizeY;

        foreach (StandardRoom room in rooms)
        {
            if (room == null)
            {
                continue;
            }

            if (room.gridPos.x < leftMost)
            {
                leftMost = (int)room.gridPos.x;
            }
            if (room.gridPos.x > rightMost)
            {
                rightMost = (int)room.gridPos.x;
            }
        }
        foreach (StandardRoom room in rooms)
        {
            if (room == null)
            {
                continue;
            }

            if (room.gridPos.x == leftMost)
            {
                if (room.gridPos.y > upMost)
                {
                    upMost = (int)room.gridPos.y;
                }
            }
            if (room.gridPos.x == rightMost)
            {
                if (room.gridPos.y < downMost)
                {
                    downMost = (int)room.gridPos.y;
                }
            }
        }

        rooms[leftMost + gridSizeX, upMost + gridSizeY] = StartingRoom.Instance(new Vector2(leftMost, upMost));
        rooms[rightMost + gridSizeX, downMost + gridSizeY] = EndingRoom.Instance(new Vector2(rightMost, downMost));
    }

    Vector2 NewPos()
    {
        int x = 0;
        int y = 0;
        Vector2 checkingPos = Vector2.zero;

        do
        {
            int index = Mathf.RoundToInt(Random.value * (takenPos.Count - 1));
            x = (int)takenPos[index].x;
            y = (int)takenPos[index].y;
            bool UpDown = (Random.value < 0.5f);
            bool xpositive = (Random.value < 0.5f);
            bool ypositive = (Random.value < 0.5f);

            if (UpDown)
            {
                if (ypositive)
                {
                    y += 1;
                } 
                else
                {
                    y -= 1;
                }
            } 
            else
            {
                if (xpositive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector2(x, y);
        } 
        while ( (takenPos.Contains(checkingPos)) || (x >= gridSizeX) || (x < -gridSizeX) || (y >= gridSizeY) || (y < -gridSizeY) );

        return checkingPos;
    }

    Vector2 SelectiveNewPos()
    {
        int index = 0;
        int inc = 0;
        int x = 0;
        int y = 0;
        Vector2 checkingPos = Vector2.zero;

        do
        {
            inc = 0;
            do
            {
                index = Mathf.RoundToInt(Random.value * (takenPos.Count - 1) );
                inc++;
            }
            while ( (NumberOfNeighbors(takenPos[index], takenPos) > 1) && (inc < 100) );

            x = (int)takenPos[index].x;
            y = (int)takenPos[index].y;
            bool genVertical = (Random.value < 0.5f);
            bool genLeft = (Random.value < 0.5f);
            bool genUp = (Random.value < 0.5f);

            if (genVertical)
            {
                if (genUp)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (genLeft)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector2(x, y);
        }
        while ((takenPos.Contains(checkingPos)) || (x >= gridSizeX) || (x < -gridSizeX) || (y >= gridSizeY) || (y < -gridSizeY));

        if (inc >= 100)
        {
            print("Error: Could not find position with only one neighbor.");
        }

        return checkingPos;
    }

    int NumberOfNeighbors(Vector2 checkingPos, List<Vector2> usedPos)
    {
        int ret = 0;

        if (usedPos.Contains(checkingPos + Vector2.right))
        {
            ret++;
        }
        if (usedPos.Contains(checkingPos + Vector2.left))
        {
            ret++;
        }
        if (usedPos.Contains(checkingPos + Vector2.up))
        {
            ret++;
        }
        if (usedPos.Contains(checkingPos + Vector2.down))
        {
            ret++;
        }

        return ret;
    }

    void SetRoomDoors()
    {
        for (int x = 0; x < ((gridSizeX * 2)); x++)
        {
            for (int y = 0; y < ((gridSizeY * 2)); y++)
            {
                if (rooms[x,y] == null)
                {
                    continue;
                }

                Vector2 gridPos = new Vector2(x, y);

                if (y - 1 < 0)
                {
                    rooms[x, y].bottom = false;
                } 
                else
                {
                    rooms[x, y].bottom = (rooms[x, y-1] != null);
                }

                if (y + 1 >= gridSizeY * 2)
                {
                    rooms[x, y].top = false;
                }
                else
                {
                    rooms[x, y].top = (rooms[x, y + 1] != null);
                }

                if (x - 1 < 0)
                {
                    rooms[x, y].left = false;
                }
                else
                {
                    rooms[x, y].left = (rooms[x - 1, y] != null);
                }

                if (x + 1 >= gridSizeX * 2)
                {
                    rooms[x, y].right = false;
                }
                else
                {
                    rooms[x, y].right = (rooms[x + 1, y] != null);
                }
            }
        }
    }
}
