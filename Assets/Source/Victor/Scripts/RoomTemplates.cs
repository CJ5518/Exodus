using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private Text numRoomsText;
    public float spawnTime;

    //public List<GameObject> allRooms;
    private int numRooms;
    //private float waitTime = 2f;
    //private bool displayed = false;

    private void Update()
    {
        numRoomsText.text = "Number of rooms: " + numRooms;
    }

    public void AddRoom()
    {
        numRooms++;
    }

    public int TotalRooms()
    {
        return numRooms;
    }
}
