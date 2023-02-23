using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HailEvent : PlagueEvent
{
    private GameObject hailstone;
    private int framecount;

    private GameObject cam;

    System.Random rnd = new System.Random();

    // Start is called before the first frame update 
    void Start()
    {
      hailstone = Resources.Load<GameObject>("prefabs/Noah/hail");
      framecount = 0;
      timeLeft = 5000;

      cam = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
       int rand = rnd.Next(-6,6);
       //Debug.Log("framnum: "+framecount+ " timeleft: " +timeLeft);
       if(timeLeft>0 && framecount%100 == 0 && (rand+8)%2 == 0) {
          Instantiate(hailstone, new Vector2(rand + cam.transform.position.x, 5+ cam.transform.position.y), Quaternion.identity, transform);
       }
       framecount++;
       timeLeft--;
       if(timeLeft <= 0){ EndEvent(); }
    }
}