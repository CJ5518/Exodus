using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.EventManager;

public class bossShoot : MonoBehaviour
{
    public GameObject snowBall;
    public Transform snowBallPos;

    private float timer, count, hailCount;
    private int snowballTracker;
    public Text sbCountText;
    

    //public EventManager em;
    
    
    // Start is called before the first frame update
    void Start()
    {
       count =  0;
       hailCount = 5;
       
       //em = Resources.Load<EventManager>("prefabs/Noah/myEventManager");
       //Instantiate(em);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        while( timer > count)
        {
            //timer = 0;
            hail();
            count += .1f;
        }

        if(timer == hailCount)
        {
            
            //em.startEvent(1);
            
            hailCount += 15;
        }

    }

    void hail()
    {
        Instantiate(snowBall, snowBallPos.position, Quaternion.identity);
        snowballTracker += 1;

        sbCountText.text = snowballTracker.ToString();
    }
    
}
