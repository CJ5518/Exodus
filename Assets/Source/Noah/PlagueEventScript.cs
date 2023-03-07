using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueEvent : MonoBehaviour
{
    
    public int framesLeft;   


    public void EndEvent()
    {
        Debug.Log("EndEvent");
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //timeLeft = 10000;        
    }

    // Update is called once per frame
    void Update()
    {
        framesLeft--;
        //Debug.Log(timeLeft);
        if(framesLeft <= 0) EndEvent();
    }
}
