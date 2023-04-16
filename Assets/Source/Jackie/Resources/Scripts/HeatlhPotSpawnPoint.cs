using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatlhPotSpawnPoint : MonoBehaviour
{
    private PotionPool potionPool;

    [SerializeField]
    private Transform spawnPointTransform;

    private bool hasSpawned;
    // Start is called before the first frame update
    void Start()
    {
        potionPool = FindObjectOfType<PotionPool>();
        hasSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasSpawned == false)
        {
            GameObject obj1 = potionPool.GetObject(); 
            obj1.transform.position = new Vector3(spawnPointTransform.position.x, spawnPointTransform.position.y, spawnPointTransform.position.z);
            obj1.transform.rotation = Quaternion.identity;
            //Instantiate(obj1, obj1.transform.position, Quaternion.identity);
            hasSpawned = true;
        }
          
    }
}
