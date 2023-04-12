using System.Collections;
using System.Collections.Generic;
using UnityEngine;//
using UnityEngine.Rendering.Universal;

public class DarkEvent : PlagueEvent
{
    private GameObject globalLight;
    private int framesLeft;

    private GameObject player;
    private Light2D pLight;
    private int lightRadius;

    // Start is called before the first frame update
    void Start()
    {

        //give light around the player
        player = GameObject.FindGameObjectWithTag("Player");
//
         pLight = player.AddComponent<Light2D>();
        pLight.color = Color.white;
        pLight.intensity = 1f;
    Debug.Log("we have given the player a light.");
    }

    public void ReceiveParameters(int difficulty, float time)
    {
        lightRadius = difficulty;

       //make it dark
        globalLight = GameObject.FindGameObjectWithTag("GlobalLight");
        Light2D gLight = globalLight.GetComponent<Light2D>();
        gLight.intensity = 1/10;
   Debug.Log("glight intensity:  " + gLight.intensity);
        framesLeft = (int )(time / Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
       //spawnTimer += Time.deltaTime; //

       framesLeft--;

       float newRadius = lightRadius + 2* Mathf.Sin(Time.time);
       pLight.pointLightOuterRadius = newRadius;
       pLight.pointLightInnerRadius = newRadius/4;

       //if(framesLeft <= 0) DarkEndEvent();
    }

    public override void EndEvent()
    {
        Debug.Log("OVERRIDE");
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
