using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    
    public GameObject currentEvent;
    private GameObject hailevent;
    private GameObject frogevent;
    private GameObject darkevent;

    private GameObject globalLight;

    // Start is called before the first frame update
    void Start()
    {     
        currentEvent = null;

        globalLight = Resources.Load<GameObject>("prefabs/Noah/GlobalLight2D");
        globalLight = Instantiate(globalLight);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startEvent(int type, int difficulty, int time)
    {  

        Debug.Log("called eventManager startEvent()");
        if(currentEvent == null && time > 0){
            
            switch(type){
            case 1: 
                 Debug.Log("error hail");
                 hailevent = Resources.Load<GameObject>("prefabs/Noah/myHailEvent");
                 currentEvent = Instantiate(hailevent);
                 currentEvent.GetComponent<HailEvent>().ReceiveParameters(difficulty, time);
                 break;
            case 2: 
                 frogevent = Resources.Load<GameObject>("prefabs/Noah/myFrogEvent");     
                 currentEvent = Instantiate(frogevent);
                 currentEvent.GetComponent<FrogEvent>().ReceiveParameters(difficulty, time);
                 break;
            case 3:      
                 darkevent = Resources.Load<GameObject>("prefabs/Noah/myDarkEvent");
                 Debug.Log("error dark");
                 currentEvent = Instantiate(darkevent);
                 currentEvent.GetComponent<DarkEvent>().ReceiveParameters(difficulty, time);
                 break;
            default: Debug.Log("Other Event Case"); break; //gay
            } 
        }
        //else{ Debug.Log("Cannot start event during event. FramesLeft: "+ currentEvent.GetComponent<PlagueEvent>().framesLeft);}
    }
    public void endEvent(){
        DestroyImmediate(currentEvent);
        currentEvent = null;
    }

}
