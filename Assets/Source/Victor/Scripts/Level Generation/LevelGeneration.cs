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

    [Header("Navmesh Config")]
    [SerializeField] private AstarPath aStarPath;
    [SerializeField] private GameObject target;



    private StandardRoom[,] rooms;
    private List<Vector2> takenPos = new List<Vector2>();
    private int gridSizeX, gridSizeY;


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

        aStarPath.Scan();
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

            target.transform.position = new Vector3(drawPos.x, drawPos.y, target.transform.position.z);

            generator.GenerateRoom(drawPos, room.type, room.top, room.bottom, room.right, room.left);
        }
    }

    void CreateRooms()
    {
        rooms = new StandardRoom[gridSizeX * 2, gridSizeY * 2];
        rooms[gridSizeX, gridSizeY] = new StandardRoom(Vector2.zero, 1);
        takenPos.Insert(0, Vector2.zero);
        Vector2 checkPos = Vector2.zero;

        float randomCompare = 0.2f;
        float randomCompareStart = 0.2f;
        float randomCompareEnd = 0.01f;

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

            rooms[(int)checkPos.x + gridSizeX, (int)checkPos.y + gridSizeY] = new StandardRoom(checkPos, 0);
            takenPos.Insert(0, checkPos);
        }
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
            bool positive = (Random.value < 0.5f);

            if (UpDown)
            {
                if (positive)
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
                if (positive)
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
            bool UpDown = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);

            if (UpDown)
            {
                if (positive)
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
                if (positive)
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
