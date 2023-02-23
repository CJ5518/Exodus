using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private EventManager em;

    private GameObject enemy;
    private Vector3 up;

    // Start is called before the first frame update
    void Start()
    {
        em = Resources.Load<EventManager>("prefabs/Noah/myEventManager");
        Instantiate(em);
 
        up = new Vector3(0,10,0);
        enemy = GameObject.Find("BaseEnemy");
        InvokeRepeating("SpawnEntity", 10.0f, 20);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("h"))
            em.startEvent(1);
    }


    private void SpawnEntity()
    {   
        Vector3 randomOffset = Random.insideUnitSphere; 
        Vector3 randomPosition =up + randomOffset;
        randomPosition.z = 0;

        Instantiate(enemy, randomPosition, Quaternion.identity);
    }
}
 