//
//  This script needs to be attached to a Game Object
//  You will need to input a Prefab, the Spawning
//      Position, and a Spawning Interval into the
//      serialized field
//  This script will repeatedly spawn an entity
//      according to the Spawning Interval
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject entity;

    [SerializeField]
    private Vector3 spawnPosition;

    [SerializeField]
    private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;

        InvokeRepeating("SpawnEntity", 1.0f, spawnInterval);
    }

    // Update is called once per frame
    private void SpawnEntity()
    {
        Vector3 randomOffset = Random.insideUnitSphere;
        Vector3 randomPosition = spawnPosition + randomOffset;
        randomPosition.z = spawnPosition.z;

        Instantiate(entity, randomPosition, Quaternion.identity);
    }
}
