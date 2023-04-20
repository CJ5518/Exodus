using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is an abstract class. A subclass representing a specific type of plagueevent must be instantiated
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
    
    
    // This is a pure virtual function. Each subclass has a method of the same name, but they have slightly different implementations on how they
    // deal with the difficulty and the time, hence the functions must be defined in the subclasses
    public virtual void ReceiveParameters(int difficulty, float time) = 0;

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
