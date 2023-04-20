using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Drag the LightBanditPool from the hierarchy into the object prefab EnemySpawnPointM
//place these where ever you want the enemies to spawn in at
public class EnemySpawnPointM : MonoBehaviour
{
    
    private LightBanditPool lightBanditPool;        //finds the refrence to the object pool in the scene

    [SerializeField]
    private Transform spawnPointTransform;          //gets the place where the prefab thsi is attached to is in the scene

    private Transform playerTransform;              //finds where the player is in the scene

    private bool hasRun;                            //make sure that only one is spawned in

    //run this script on start
    void Start()
    {
        lightBanditPool = FindObjectOfType<LightBanditPool>();
        playerTransform = GameObject.Find("Player").transform;       //this will get the position of the player
        hasRun = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if the spawn point is within a certain distance of the player then the enemy is spawned into the scene
        float distance = Vector3.Distance(spawnPointTransform.position, playerTransform.position);
        if(distance <= 30 && hasRun == false)
        {
            GameObject obj1 = lightBanditPool.GetObject(); 
            obj1.transform.position = new Vector3(spawnPointTransform.position.x, spawnPointTransform.position.y, spawnPointTransform.position.z);
            obj1.transform.rotation = Quaternion.identity;
            hasRun = true;
        }
    }
}
//note: despawn is taken care of by the enemy script itself