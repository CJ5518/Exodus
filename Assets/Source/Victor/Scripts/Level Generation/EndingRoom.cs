using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingRoom : StandardRoom
{
    private GameObject roomInstance;
    private GameObject instObject;

    public EndingRoom(Vector2 _gridPos) : base(_gridPos)
    {
        gridPos = _gridPos;
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
