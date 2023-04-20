using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is the script that is used to call the ranged enemies in their proper spawn locations
//just be sure to drag the prefab "ArrowPool" into the heirarchy first otherwise it will not work...
public class EnemySpawnPointR : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPointTransform;      //this gets the location of the spawnpoint (where the prefab is located)

    private Transform playerTransform;          //this is where the player is located in the scene

    private bool hasRun;                        //makes sure that only one enemy is spawned in

    [SerializeField]
    private GameObject rangedEnemy;             //this gets the correct game object to be put into the scene

    private Vector3 spawnLocation;              //where is the spawn location of the enemy

    //do these on startup
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;       //this will get the position of the player
        hasRun = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if the enemy is within a certain range of the enemy spawn location then the enemy is spawned in
        float distance = Vector3.Distance(spawnPointTransform.position, playerTransform.position);
        if(distance <= 45 && hasRun == false)
        {
            spawnLocation = new Vector3(spawnPointTransform.position.x, spawnPointTransform.position.y, spawnPointTransform.position.z);
            Instantiate(rangedEnemy, spawnLocation, Quaternion.identity);
            hasRun = true;
        }
    }
}
//note: The despawn it taken care of by the enemy script