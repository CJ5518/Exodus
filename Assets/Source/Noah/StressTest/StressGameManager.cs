using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressGameManager : MonoBehaviour
{
    private EventManager em;

    private GameObject enemy;
    private Vector3 up;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
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
        count++;
        if(Input.GetKey("0")){
            Debug.Log("count of event managers: " + count);
            EventManager myem = Instantiate(em);
            myem.startEvent(1, 10, 10);

            if (count > 80) {
                Time.timeScale = 0;
                Debug.Log("too many to see");
                Destroy(this);
            }
        }
        /*
        if(Input.GetKey("0")){
            Debug.Log("normal run, difficulty=5, time=10 seconds");
            em.startEvent(1, 5, 10);
        }
        if(Input.GetKey("1")){
            Debug.Log("difficulty boundary test, max difficulty=300, time=10 seconds");
            em.startEvent(1, 300, 10);
        }
        if(Input.GetKey("2")){
            Debug.Log("difficulty boundary test, difficulty=301, time=10 seconds");
            em.startEvent(1, 301, 10);
        }
        if(Input.GetKey("3")){
            Debug.Log("event type boundary test, calling event type 2 which doesn't exist (yet)");
            em.startEvent(2, 5, 5);
        }
        */
    }


    private void SpawnEntity()
    {   
        Vector3 randomOffset = Random.insideUnitSphere; 
        Vector3 randomPosition =up + randomOffset;
        randomPosition.z = 0;

        Instantiate(enemy, randomPosition, Quaternion.identity);
    }
}
 