using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardRoom
{
    public Vector2 gridPos;

    public int type;

    public bool top, bottom, right, left;

    public StandardRoom(Vector2 _gridPos, int _type)
    {
        gridPos = _gridPos;
        type = _type;
    }
}
