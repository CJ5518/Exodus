using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogFight : MonoBehaviour
{
    private static int frogsKilled;

    private EventManager eventManager;

    // Start is called before the first frame update
    void Start()
    {
        frogsKilled = 0;

        // get the singleton instance of the Event manager and start the first wave
        eventManager = EventManager.Instance;
        eventManager.startEvent(2, 2, 8);
    }

    public void killedFrog()
    {
        frogsKilled++;
        Debug.Log("frogs killed: "+frogsKilled);
        // when there is one frog left on the first wave, send the second wave 
        if(frogsKilled == 4){
            Debug.Log("You beat the first wave");
            eventManager.startEvent(2, 4, 2);
        }
        // when there is one frog left on the second wave, send the last wave
        if(frogsKilled == 12){
            Debug.Log("You beat the second wave");
            eventManager.startEvent(2, 7, 6);
        }
        // after most frogs are killed, load the boss scene
        if(frogsKilled == 26){
            Debug.Log("You beat the last wave");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //SceneManager.LoadScene("BossScene_V2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
