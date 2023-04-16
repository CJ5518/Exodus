using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FrogEvent : PlagueEvent
{
    private GameObject frog;
    private int spawncount;
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
        //the frogs event does not depend on time at the moment
        spawncount = difficulty;
        //Debug.Log( spawncount);
    }

    // Update is called once per frame
    void Update()
    {
       spawnTimer += Time.deltaTime;

       if(spawnTimer >= 5 && count < spawncount){
           GameObject obj1 = Instantiate(frog, new Vector2(cam.transform.position.x - 8, cam.transform.position.y),Quaternion.identity, transform);
           GameObject obj2 = Instantiate(frog, new Vector2(cam.transform.position.x + 8, cam.transform.position.y),Quaternion.identity, transform);
           obj1.transform.SetParent(transform.parent); // this is so if the event ends while frogs are still alive, the
           obj2.transform.SetParent(transform.parent); // frogs will not be destroyed, because there new parent still exists
           count++;
           spawnTimer = 0;
       }
       //Debug.Log(count +"/"+ spawncount);
       if(count == spawncount) EndEvent();
    }
}
