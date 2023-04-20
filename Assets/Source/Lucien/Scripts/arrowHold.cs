using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a simple script that checks the place the enemy is on the map currently so that the enemies
//arrow is fired from the correct location and not from a random place on the current scene
public class arrowHold : MonoBehaviour
{
    [SerializeField]
    private Transform enemy;            //this gets the enemy position and where it is aiming

    private void Update()
    {
        transform.localScale = enemy.localScale;
    }
}
