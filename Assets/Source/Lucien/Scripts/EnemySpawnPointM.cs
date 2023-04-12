using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Drag the LightBanditPool from the hierarchy into the object prefab EnemySpawnPointM
//place these where ever you want the enemies to spawn in at

public class EnemySpawnPointM : MonoBehaviour
{
    
    private LightBanditPool lightBanditPool;

    [SerializeField]
    private Transform spawnPointTransform;

    private Transform playerTransform;
    private EnemyJumpAttack enemyJumpAttack;

    private bool hasRun;

    void Start()
    {
        lightBanditPool = FindObjectOfType<LightBanditPool>();
        playerTransform = GameObject.Find("Player").transform;       //this will get the position of the player
        enemyJumpAttack = GetComponent<EnemyJumpAttack>();
        hasRun = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(spawnPointTransform.position, playerTransform.position);
        if(distance <= 75 && hasRun == false)
        {
            GameObject obj1 = lightBanditPool.GetObject(); 
            obj1.transform.position = new Vector3(spawnPointTransform.position.x, spawnPointTransform.position.y, spawnPointTransform.position.z);
            obj1.transform.rotation = Quaternion.identity;
            hasRun = true;
        }
    }
}
