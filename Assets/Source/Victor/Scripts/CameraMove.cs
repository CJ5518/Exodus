using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private GameObject player;
    private bool playerFound;
    private Vector3 playerPos;

    void Update()
    {
        if (playerFound)
        {
            playerPos = new Vector3(Mathf.Round(player.transform.position.x / 48) * 48, Mathf.Round(player.transform.position.y / 27) * 27, -10);

            transform.position = playerPos;
        }
    }
    
    public void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerFound = true;
    }
}
