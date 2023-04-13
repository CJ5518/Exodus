using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.EventManager;

public class BossShoot : MonoBehaviour
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
       hailCount = 10;
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
            //hail();
            Instantiate(snowBall, snowBallPos.position, Quaternion.identity);
            count += 20f;
        }

        if(timer == hailCount)
        {
            
            //em.startEvent(1);
            
            hailCount += 15;
        }

    }

    void hail()
    {
        
        snowballTracker += 1;

        sbCountText.text = snowballTracker.ToString();
    }
    
}
