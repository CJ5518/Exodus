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
    public static float timeElapsed;
    public static int maxTime;


//Singleton class - any function can get this one instance with: EventManager em = EventManager.Instance;
    private static EventManager instance;

    public static EventManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            globalLight = Resources.Load<GameObject>("prefabs/Noah/GlobalLight2D");
            globalLight = Instantiate(globalLight);
            DontDestroyOnLoad(globalLight);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {     
        currentEvent = null;
        timeElapsed = 0f;
        maxTime = 0;
    }

    // Update is called once per frame
    void Update()
    {                                             
        //Debug.Log(timeElapsed+"/"+maxTime);
        timeElapsed += Time.deltaTime;
        if(isEvent == 1 && timeElapsed> maxTime){
            Debug.Log("CallingEndEvent() from EventManager");
            s_currentEvent.GetComponent<PlagueEvent>().EndEvent();
            isEvent = 0;
            timeElapsed = 0;
        }
        if(Input.GetKey("["))
            startEvent(3, 2, 15);
        if(Input.GetKey("]"))
            startEvent(3, 5, 10);
        if(Input.GetKey("\\"))
            startEvent(3, 9, 5); 

        if(Input.GetKey("1"))
            startEvent(1, 5, 10);
        if(Input.GetKey("2"))
            startEvent(1, 7, 5);
        if(Input.GetKey("3"))
            startEvent(1, 9, 5);  
    }

    public void startEvent(int type, int difficulty, int time)
    {  
        Debug.Log("called eventManager startEvent() "+timeElapsed+"/"+maxTime);
        if(isEvent == 0 && time > 0){
            timeElapsed = 0; 
            isEvent = 1;
            switch(type){
            case 1: 
                 Debug.Log("start hail");
                 maxTime = time;
                 hailevent = Resources.Load<GameObject>("prefabs/Noah/myHailEvent");
                 currentEvent = Instantiate(hailevent);
                 currentEvent.GetComponent<HailEvent>().ReceiveParameters(difficulty, time);
                 break;
            case 2: 
                 Debug.Log("start frog");
                 //time for this event is used as an interval between difficulty spawns
                 maxTime = time * difficulty + 1; 
                 frogevent = Resources.Load<GameObject>("prefabs/Noah/myFrogEvent");     
                 currentEvent = Instantiate(frogevent);
                 currentEvent.GetComponent<FrogEvent>().ReceiveParameters(difficulty, time);
                 break;
            case 3:   
                 Debug.Log("start dark");
                 maxTime = time;   
                 darkevent = Resources.Load<GameObject>("prefabs/Noah/myDarkEvent");
                 currentEvent = Instantiate(darkevent);
                 currentEvent.GetComponent<DarkEvent>().ReceiveParameters(difficulty, time);
                 break;
            default: Debug.Log("Other Event Case"); break; //gay
            } 
            s_currentEvent = currentEvent;
        }
        else
        { 
            Debug.Log("Cannot start event during event.");
        }
    }

    public GameObject getCurrEvent()
    {
        return currentEvent;
    }


  //this function is used for the boundary tests, because DestroyImmediate is required there instead of Destroy
    public void endEvent(){
        DestroyImmediate(currentEvent);
        //currentEvent = null;
        isEvent = 0;
    }

}




