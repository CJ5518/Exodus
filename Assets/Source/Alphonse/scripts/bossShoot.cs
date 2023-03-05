using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventManager;

public class bossShoot : MonoBehaviour
{
    public GameObject snowBall;
    public Transform snowBallPos;

    private float timer, count, hailCount;

    
    // Start is called before the first frame update
    void Start()
    {
       count =  0;
       hailCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        while( timer > count)
        {
            //timer = 0;
            hail();
            count += 2f;
        }

        if(timer == hailCount)
        {
            EventManager em = Resources.Load<EventManager>("prefabs/Noah/myEventManager");
            Instantiate(em);
            em.startEvent(1);
            
            hailCount += 15;
        }

    }

    void hail()
    {
        Instantiate(snowBall, snowBallPos.position, Quaternion.identity);
    }
}
