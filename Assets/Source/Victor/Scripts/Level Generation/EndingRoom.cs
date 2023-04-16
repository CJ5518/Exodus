using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingRoom : StandardRoom
{
    private static EndingRoom instance = null;

    private GameObject roomInstance;
    private GameObject instObject;

    protected EndingRoom(Vector2 _gridPos) : base(_gridPos)
    {
        gridPos = _gridPos;
    }

    public static EndingRoom Instance(Vector2 _gridPos) {
        if (instance == null) {
            instance = new EndingRoom(_gridPos);
        }
        instance.gridPos = _gridPos;

        return instance;
    }

    public override void SetRoom(GameObject _roomInstance, GameObject targetObject, GameObject startObject)
    {
        roomInstance = _roomInstance;

        instObject = targetObject;

        Vector3 objPos = Vector2.zero;


        for (int i = 0; i < roomInstance.transform.childCount; i++)
        {
            if (roomInstance.transform.GetChild(i).CompareTag("TargetLocation"))
            {
                objPos = roomInstance.transform.GetChild(i).position;
            }
        }


        GameObject.Instantiate(instObject, objPos, Quaternion.identity);
    }
}
