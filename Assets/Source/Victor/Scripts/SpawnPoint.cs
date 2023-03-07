using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour 
{
    [SerializeField]
    private int doorDirection;
    // Top     : 1
    // Right   : 2
    // Bottom  : 3
    // Left    : 4


    private RoomTemplates rooms;
    private int rand;
    public bool spawned;

    public float waitTime = 4f;

    private void Start()
    {
        //Destroy(gameObject, waitTime);
        rooms = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        Invoke("Spawn", .001f);
    }

    private void Spawn() 
    {
        if (spawned)
        {
            return;
        }

        if (doorDirection == 1) {

            rand = Random.Range(0, rooms.roomsWithTopDoor.Length);
            Instantiate(rooms.roomsWithTopDoor[rand], transform.position, rooms.roomsWithTopDoor[rand].transform.rotation);
            
        } else if (doorDirection == 2) {

            rand = Random.Range(0, rooms.roomsWithRightDoor.Length);
            Instantiate(rooms.roomsWithRightDoor[rand], transform.position, rooms.roomsWithRightDoor[rand].transform.rotation);

        } else if (doorDirection == 3) {

            rand = Random.Range(0, rooms.roomsWithBottomDoor.Length);
            Instantiate(rooms.roomsWithBottomDoor[rand], transform.position, rooms.roomsWithBottomDoor[rand].transform.rotation);

        } else if (doorDirection == 4) {

            rand = Random.Range(0, rooms.roomsWithLeftDoor.Length);
            Instantiate(rooms.roomsWithLeftDoor[rand], transform.position, rooms.roomsWithLeftDoor[rand].transform.rotation);

        }

        spawned = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            spawned = true;
        }
    }
}
