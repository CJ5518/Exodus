using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossEncounter : MonoBehaviour
{
    protected float count;
    protected float interval;

    protected GameObject getHail;

    ParticleSystem hail;
    // Start is called before the first frame update
    void Start()
    {   
        getHail.name  = "hailPlagueAbility";
        hail = getHail.GetComponent<ParticleSystem>();
        //hail.enableEmission = false;
        hail.Stop();
    }

    // Update is called once per frame
    void Update()
    {   
        count += Time.deltaTime;
        if(count % 10 == 0)
        {
            hail.Play();
            interval = count % 60;

        } else if(interval % 10 == 0)
        {
            hail.Stop();
            interval = 0;
        }

        
    }
}
