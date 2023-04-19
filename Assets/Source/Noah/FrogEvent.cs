using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FrogEvent : PlagueEvent
{
    private GameObject frog;
    private int spawnCount;
    private float spawnInterval;
    private int count;
    private float spawnTimer;

    private GameObject cam;

    System.Random rnd = new System.Random();

    // Start is called before the first frame update 
    void Start()
    {
      frog = Resources.Load<GameObject>("prefabs/Noah/Frog");
      spawnTimer = 1;
      count = 0;
      cam = GameObject.FindWithTag("MainCamera");
    }

    public void ReceiveParameters(int difficulty, float time)
    {
        //in this event the time parameter specifies the time between spawns of frogs
        spawnInterval = time;
       
        //the difficulty parameter specifies how many frogs will spawn, and how fast they will jump
        spawnCount = difficulty;
        //Debug.Log( spawnCount);
    }

    // Update is called once per frame
    void Update()
    {
       spawnTimer += Time.deltaTime;

       if(spawnTimer >= spawnInterval && count < spawnCount){
     Debug.Log("interval:"+spawnInterval+" spawnCount: "+spawnCount);
           GameObject obj1 = Instantiate(frog, new Vector2(cam.transform.position.x - 8, cam.transform.position.y),Quaternion.identity, transform);
           GameObject obj2 = Instantiate(frog, new Vector2(cam.transform.position.x + 8, cam.transform.position.y),Quaternion.identity, transform);

           obj1.transform.SetParent(transform.parent); // this is so if the event ends while frogs are still alive, the
           obj2.transform.SetParent(transform.parent); // frogs will not be destroyed, because their new parent still exists

           obj1.GetComponent<FrogScript>().receiveSpeed(spawnCount); //this is also the difficulty of an individual frog
           obj2.GetComponent<FrogScript>().receiveSpeed(spawnCount); 

           count++;
           spawnTimer = 0;
       }
       //Debug.Log(count +"/"+ spawncount);
    }
}
