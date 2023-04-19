using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueEvent : MonoBehaviour
{
    // this is a relic from before EventManager took over managing the time alotted to events
    // public int framesLeft;   

    // This function just destroys the game object (the ongoing event)
    // This function is virtual because the subclass dark event must do extra things to end properly
    public virtual void EndEvent()
    {
        Debug.Log("EndEvent() called from parent class PlagueEvent");
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //framseLeft = 10000;        
    }

    // Update is called once per frame
    void Update()
    {
        //framesLeft--;
        //Debug.Log(timeLeft);
        //if(framesLeft <= 0) EndEvent();
    }
}
