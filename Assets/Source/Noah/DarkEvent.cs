using System.Collections;
using System.Collections.Generic;
using UnityEngine;//
using UnityEngine.Rendering.Universal;

public class DarkEvent : MonoBehaviour
{
    private GameObject globalLight;
    private int framesLeft;

    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {

        globalLight = GameObject.FindGameObjectWithTag("GlobalLight");

        //give light around the player
        player = GameObject.FindGameObjectWithTag("Player");
//
        Light2D light = player.AddComponent<Light2D>();
        light.color = Color.white;
        light.intensity = 1f;

    }

    public void ReceiveParameters(int difficulty, float time)
    {
        //the frogs event does not depend on time at the moment
        //spawncount = difficulty;

       //make it dark
        Light2D gLight = globalLight.GetComponent<Light2D>();
        gLight.intensity = 1f - (1/10 * (float)difficulty);

        framesLeft = (int )(time / Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
       //spawnTimer += Time.deltaTime; //

       framesLeft--;

       float newRadius = 2 + 2* Mathf.Sin(Time.time);


       if(framesLeft <= 0) DarkEndEvent();
    }

    private void DarkEndEvent()
    {
        Light2D gLight = globalLight.GetComponent<Light2D>();
        gLight.intensity = 1f;
        Destroy(this);
    }
}
