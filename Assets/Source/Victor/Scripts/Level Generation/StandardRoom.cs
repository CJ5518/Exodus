using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardRoom
{
    public Vector2 gridPos;
    public bool top, bottom, right, left;

    private GameObject roomInstance;

    public StandardRoom(Vector2 _gridPos)
    {
        gridPos = _gridPos;
    }

    public bool[] Doors()
    {
        bool[] doors = { top, bottom, right, left };
        return doors;
    }

    public virtual void SetRoom(GameObject _roomInstance, GameObject goalObject, GameObject startObject)
    {
        roomInstance = _roomInstance;
    }
}
