using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularKey_Spawn : MonoBehaviour
{
    
    [SerializeField]
    private Transform spawnPointTransform;

    public GameObject RegularKeyPrefab;
    private bool hasSpawned;

    // Start is called before the first frame update
    void Start()
    {
        hasSpawned = false;      
    }

    // Update is called once per frame
    void Update()
    {
        if(hasSpawned == false) //Only spawn once
        {
            Vector3 SpawnPosition = new Vector3(spawnPointTransform.position.x, spawnPointTransform.position.y, spawnPointTransform.position.z);
            Instantiate(RegularKeyPrefab, SpawnPosition, Quaternion.identity);
            hasSpawned = true;
        }
    }
}
