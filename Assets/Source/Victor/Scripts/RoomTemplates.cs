using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    [SerializeField]
    public GameObject[] roomsWithBottomDoor;
    [SerializeField]
    public GameObject[] roomsWithTopDoor;
    [SerializeField]
    public GameObject[] roomsWithLeftDoor;
    [SerializeField]
    public GameObject[] roomsWithRightDoor;

    //public List<GameObject> allRooms;
    private int numRooms;
    private float waitTime = 2f;
    private bool displayed = false;

    public void AddRoom()
    {
        numRooms++;
    }

    public int TotalRooms()
    {
        return numRooms;
    }
}
