using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    
    private GameObject currentEvent;
    private GameObject hailevent;

    // Start is called before the first frame update
    void Start()
    {     
        currentEvent = null;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startEvent(int type, int difficulty, int time)
    {  
        hailevent = Resources.Load<GameObject>("prefabs/Noah/myHailEvent");
        Debug.Log("called eventManager startEvent()");
        if(currentEvent == null){
            
            switch(type){
            case 1: 
                 currentEvent = Instantiate(hailevent);
                 currentEvent.GetComponent<HailEvent>().ReceiveParameters(difficulty, time);
                 break;
            default: Debug.Log("Other Event Case"); break;
            } 
        }
        else{ Debug.Log("Cannot start event during event. FramesLeft: "+ currentEvent.GetComponent<PlagueEvent>().framesLeft);
        }
    }

}
