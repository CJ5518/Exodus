using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HailEvent : PlagueEvent
{
    private GameObject hailStone;
    private int frameCount;
    public int spawnInterval;

    private GameObject cam;

    System.Random rnd = new System.Random();

    // Start is called before the first frame update 
    void Start()
    {
        // load the hailStone prefab that will be repetetively instatiated
        hailStone = Resources.Load<GameObject>("prefabs/Noah/hail");
        frameCount = 0;
        
        // will use the camera position as a reference point to spawing the hailStones
        cam = GameObject.FindWithTag("MainCamera");
    }

    public void ReceiveParameters(int difficulty, float time)
    {
        // The difficulty will determine how frequently hailStones are instantiated.
        // For every 1 difficulty level lower, the interval between spawns is doubled
        int i = 10-difficulty;
        spawnInterval = 1;
        while(i>0) {
           spawnInterval = 2*spawnInterval;
           i--;
        }
        // Debug.Log("spawn interval: "+ spawnInterval);
        
        // the time parameter is no longer used by hail event
    }

    // Update is called once per frame
    void Update()
    {
        // +/- 22 is the approximate width of the camera and 10 is the height above the center of the camera
        int rand = rnd.Next(-22,22);
        if(frameCount%(spawnInterval) == 0) {
            GameObject obj = Instantiate(hailStone, new Vector2(rand + cam.transform.position.x, 10+ cam.transform.position.y), Quaternion.identity, transform);
            // set the new hailstone's parent to the EventManager so that when this event ends, the hailstones on screen are not immediately destroyed
            obj.transform.SetParent(transform.parent);
        }
        frameCount++;
    }
}

