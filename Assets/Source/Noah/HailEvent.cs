using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HailEvent : PlagueEvent
{
    private GameObject hailstone;
    private int framecount;
    private int diflvl;

    private GameObject cam;

    System.Random rnd = new System.Random();

    // Start is called before the first frame update 
    void Start()
    {
      hailstone = Resources.Load<GameObject>("prefabs/Noah/hail");
      framecount = 0;

      cam = GameObject.FindWithTag("MainCamera");
    }

    public void ReceiveParameters(int difficulty, float time)
    {
        diflvl = difficulty;
        framesLeft = (int )(time / Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
       int rand = rnd.Next(-6,6);
       //Debug.Log("framnum: "+framecount+ " timeleft: " +timeLeft);
       if(framesLeft>0 && framecount%(300/diflvl) == 0 && (rand+8)%2 == 0) {
          GameObject obj = Instantiate(hailstone, new Vector2(rand + cam.transform.position.x, 5+ cam.transform.position.y), Quaternion.identity, transform);
          obj.transform.SetParent(transform.parent);
       }
       framecount++;
       framesLeft--;
       if(framesLeft <= 0){ EndEvent(); }
    }
}