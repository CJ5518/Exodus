using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatlhPotSpawnPoint : MonoBehaviour
{
    private PotionPool potionPool;

    [SerializeField]
    private Transform spawnPointTransform;

    private Transform playerTransform;
    private bool hasSpawned;
    // Start is called before the first frame update
    void Start()
    {
        potionPool = FindObjectOfType<PotionPool>();
        playerTransform = GameObject.Find("Player").transform; 
        hasSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(spawnPointTransform.position, playerTransform.position);
        if(hasSpawned == false & distance < 60)
        {
            GameObject obj1 = potionPool.GetObject(); 
            obj1.transform.position = new Vector3(spawnPointTransform.position.x, spawnPointTransform.position.y, spawnPointTransform.position.z);
            obj1.transform.rotation = Quaternion.identity;
            hasSpawned = true;
        }
          
    }
}
