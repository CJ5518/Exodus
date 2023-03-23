using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressGM : MonoBehaviour
{
    private EventManager em;

    private GameObject enemy;
    private Vector3 up;

    // Start is called before the first frame update
    void Start()
    {
        em = Resources.Load<EventManager>("prefabs/Noah/myEventManager");
        Instantiate(em);
 
        Debug.Log("press numbers 1-6 to run different boundary and stress tests");
        //up = new Vector3(0,10,0);
        //enemy = GameObject.Find("BaseEnemy");
        //InvokeRepeating("SpawnEntity", 1.0f, 2);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("0")){
            Debug.Log("normal run, difficulty=5, time=10 seconds");
            em.startEvent(1, 0, 10);
        }
        if(Input.GetKey("1")){
            Debug.Log("difficulty boundary test, max difficulty=300, time=10 seconds");
            em.startEvent(1, 1, 10);
        }
        if(Input.GetKey("2")){
            Debug.Log("difficulty boundary test, difficulty=301, time=10 seconds");
            em.startEvent(1, 2, 10);
        }
        if(Input.GetKey("3")){
            Debug.Log("event type boundary test, calling event type 2 which doesn't exist (yet)");
            em.startEvent(1, 3, 10);
        }
        if(Input.GetKey("4")){
            Debug.Log("event type boundary test, calling event type 2 which doesn't exist (yet)");
            em.startEvent(1, 4, 10);
        }
        if(Input.GetKey("5")){
            Debug.Log("event type boundary test, calling event type 2 which doesn't exist (yet)");
            em.startEvent(1, 5, 10);
        }
        if(Input.GetKey("6")){
            Debug.Log("event type boundary test, calling event type 2 which doesn't exist (yet)");
            em.startEvent(1, 6, 10);
        }
        if(Input.GetKey("7")){
            Debug.Log("event type boundary test, calling event type 2 which doesn't exist (yet)");
            em.startEvent(1, 7, 10);
        }
        if(Input.GetKey("8")){
            Debug.Log("event type boundary test, calling event type 2 which doesn't exist (yet)");
            em.startEvent(1, 8, 10);
        }
        if(Input.GetKey("9")){
            Debug.Log("event type boundary test, calling event type 2 which doesn't exist (yet)");
            em.startEvent(1, 9, 10);
        }
        if(Input.GetKey("-")){
            Debug.Log("event type boundary test, calling event type 2 which doesn't exist (yet)");
            em.startEvent(1, 10, 10);
        }


    }


    private void SpawnEntity()
    {   
        Vector3 randomOffset = Random.insideUnitSphere; 
        Vector3 randomPosition =up + randomOffset;
        randomPosition.z = 0;

        Instantiate(enemy, randomPosition, Quaternion.identity);
    }
}
 