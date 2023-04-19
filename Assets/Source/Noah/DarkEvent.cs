using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; 

public class DarkEvent : PlagueEvent
{
    private GameObject globalLight;

    private GameObject player;
    private Light2D playerLight;
    private int lightRadius;

    // Start is called before the first frame update
    void Start()
    {

        // find player to give light around the player
        player = GameObject.FindGameObjectWithTag("Player");
        playerLight = player.AddComponent<Light2D>();
        
        // can't add component that already exists, so this line will set playerLight for 2,3,4th... calls of darkEvent
        playerLight = player.GetComponent<Light2D>(); 
                                                  
        playerLight.color = Color.white;
        playerLight.intensity = 1f;
        //Debug.Log("we have given the player a light.");
    }

    public void ReceiveParameters(int difficulty, float time)
    {
        // The DarkEvent does not use the time parameter
    
        // Lower difficulty will have larger light
        lightRadius = 10 - difficulty;

        // make it dark by changing the intensity of global Light according to difficulty
        globalLight = GameObject.FindGameObjectWithTag("GlobalLight");
        Light2D gLight = globalLight.GetComponent<Light2D>();

        // the easier difficulties will still be able to barely see their surrounds
        if(difficulty < 5) {
            gLight.intensity = 0.2f;
        }
        else  // harder difficulties get pitch black
        {
            gLight.intensity = 0;
        }
        Debug.Log("glight intensity:  " + gLight.intensity);
    }

    // Update is called once per frame. It expands and retracts the light centered at the player according to Time.time
    void Update()
    {
       float newRadius = lightRadius + 2* Mathf.Sin(Time.time);
       playerLight.pointLightOuterRadius = newRadius;
       playerLight.pointLightInnerRadius = newRadius/4;

    }

    // This dynamic type EndEvent() function cannot just destroy the event. It first has to reset the lights back to normal.
    public override void EndEvent()
    {
        // Debug.Log("OVERRIDE");
        // turn down the player light, or it will remain seen. Light intensity stacks in this rendering package
        playerLight.pointLightOuterRadius = 0;
        playerLight.pointLightInnerRadius = 0;
        
        //reset the global Light
        Light2D gLight = globalLight.GetComponent<Light2D>();
        gLight.intensity = 1f;
        Destroy(this);
    }

    // old function before OVERRIDE EndEvent was implemented
    private void DarkEndEvent()
    {
        Light2D gLight = globalLight.GetComponent<Light2D>();
        gLight.intensity = 1f;
        Destroy(this);
    }
}


