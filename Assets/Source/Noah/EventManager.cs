using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    
    public GameObject currentEvent;
    private static GameObject s_currentEvent;
    private static int isEvent;
    private GameObject hailevent;
    private GameObject frogevent;
    private GameObject darkevent;

    private GameObject globalLight;
    [SerializeField]
    public static float timeElapsed;
    [SerializeField]
    public static int maxTime;

    // Start is called before the first frame update
    void Start()
    {     
        currentEvent = null;
        timeElapsed = 0f;

        globalLight = Resources.Load<GameObject>("prefabs/Noah/GlobalLight2D");
        globalLight = Instantiate(globalLight);

    }

    // Update is called once per frame
    void Update()
    {                                             
        Debug.Log(timeElapsed+"/"+maxTime);
        timeElapsed += Time.deltaTime;
        if(isEvent == 1 && timeElapsed> maxTime){
            Debug.Log("CallingEndEvent() from EventManager");
            s_currentEvent.GetComponent<PlagueEvent>().EndEvent();
            isEvent = 0;
            timeElapsed = 0;
        }
   
    }

    public void startEvent(int type, int difficulty, int time)
    {  
        timeElapsed = 0; 
        maxTime = time;
        Debug.Log("called eventManager startEvent() "+timeElapsed+"/"+maxTime);
        if(isEvent == 0 && time > 0){
            isEvent = 1;
            switch(type){
            case 1: 
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
                 currentEvent = Instantiate(darkevent);
                 currentEvent.GetComponent<DarkEvent>().ReceiveParameters(difficulty, time);
                 break;
            default: Debug.Log("Other Event Case"); break; //gay
            } 
            s_currentEvent = currentEvent;
        }
        //else{ Debug.Log("Cannot start event during event. FramesLeft: "+ currentEvent.GetComponent<PlagueEvent>().framesLeft);}
    }

    private GameObject getCurrEvent()
    {
        return currentEvent;
    }


  //this function is used for the boundary tests, because DestroyImmediate is required there instead of Destroy
    public void endEvent(){
        DestroyImmediate(currentEvent);
        currentEvent = null;
    }

}
