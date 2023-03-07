using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates rooms;

    private void Start()
    {
        rooms = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        //rooms.allRooms.Add(this.gameObject);
        rooms.AddRoom();
    }
}
