using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantRoom : StandardRoom
{
    private static MerchantRoom instance = null;

    private GameObject roomInstance;
    private GameObject instObject;

    protected MerchantRoom(Vector2 _gridPos) : base(_gridPos)
    {
        gridPos = _gridPos;
    }

    public static MerchantRoom Instance(Vector2 _gridPos) {
        if (instance == null) {
            instance = new MerchantRoom(_gridPos);
        }
        instance.gridPos = _gridPos;

        return instance;
    }

    public override void SetRoom(GameObject _roomInstance, GameObject targetObject, GameObject startObject, GameObject merchantObject)
    {
        roomInstance = _roomInstance;

        instObject = merchantObject;

        Vector3 objPos = Vector2.zero;


        for (int i = 0; i < roomInstance.transform.childCount; i++)
        {
            if (roomInstance.transform.GetChild(i).CompareTag("MerchantSpawn"))
            {
                objPos = roomInstance.transform.GetChild(i).position;
            }
        }


        GameObject.Instantiate(instObject, objPos, Quaternion.identity);
    }
}
