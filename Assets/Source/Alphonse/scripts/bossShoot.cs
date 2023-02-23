using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventManager;

public class bossShoot : MonoBehaviour
{
    public GameObject snowBall;
    public Transform snowBallPos;

    private float timer, count;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >2)
        {
            timer = 0;
            hail();
        }

        if(timer > 20)
        {
            EventManager em = Resources.Load<EventManager>("prefabs/Noah/myEventManager");
            Instantiate(em);
            em.startEvent(1); //1 corresponds to hailtype event

            count += Time.deltaTime;
        }

    }

    void hail()
    {
        Instantiate(snowBall, snowBallPos.position, Quaternion.identity);
    }
}
