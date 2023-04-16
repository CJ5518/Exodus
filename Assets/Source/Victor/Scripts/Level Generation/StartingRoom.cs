using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingRoom : StandardRoom
{
    private static StartingRoom instance = null;

    private GameObject roomInstance;
    private GameObject instObject;

    protected StartingRoom(Vector2 _gridPos) : base(_gridPos)
    {
        gridPos = _gridPos;
    }

    public static StartingRoom Instance(Vector2 _gridPos) {
        if (instance == null) {
            instance = new StartingRoom(_gridPos);
        }
        instance.gridPos = _gridPos;

        return instance;
    }

    public override void SetRoom(GameObject _roomInstance, GameObject goalObject, GameObject startObject)
    {
        roomInstance = _roomInstance;

        instObject = startObject;

        Vector3 objPos = Vector3.zero;

        Debug.Log("Started Searching for Spawning Location");

        for (int i = 0; i < roomInstance.transform.childCount; i++)
        {
            if (roomInstance.transform.GetChild(i).CompareTag("SpawnLocation"))
            {
                Debug.Log("Found Spawning Location");
                objPos = roomInstance.transform.GetChild(i).position;
            }
        }


        GameObject player = GameObject.Instantiate(instObject, objPos, Quaternion.identity) as GameObject;
        player.name = instObject.name;
        GameObject playerCam = player.transform.GetChild(0).gameObject;
        playerCam.SetActive(false);
    }
}
