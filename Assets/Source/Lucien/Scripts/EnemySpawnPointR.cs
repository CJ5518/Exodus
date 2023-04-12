using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is the script that is used to call the ranged enemies in their proper spawn locations
//just be sure to drag the prefab "ArrowPool" into the heirarchy first otherwise it will not work...

public class EnemySpawnPointR : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPointTransform;

    private Transform playerTransform;

    private bool hasRun;

    [SerializeField]
    private GameObject rangedEnemy;

    private Vector3 spawnLocation;

    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;       //this will get the position of the player
        //rangedEnemy = GameObject.Find("Archer");
        hasRun = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(spawnPointTransform.position, playerTransform.position);
        if(distance <= 75 && hasRun == false)
        {
            spawnLocation = new Vector3(spawnPointTransform.position.x, spawnPointTransform.position.y, spawnPointTransform.position.z);
            Instantiate(rangedEnemy, spawnLocation, Quaternion.identity);
            hasRun = true;
        }
    }
}
