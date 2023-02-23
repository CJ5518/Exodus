using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class hailfall : MonoBehaviour
{
    private int rand;
    private float move; 

    private Rigidbody2D rigidBody2D;
  
    private Vector2 fallleft = new Vector2(-.8f, -1);
    private Vector2 fallright = new Vector2(.8f, -1);

    System.Random rnd = new System.Random();
    

    // Start is called before the first frame update
    void Start()
    {
        rand = rnd.Next(2,6);

        rigidBody2D = GetComponent<Rigidbody2D>();
        
        if(rand%2 == 0)rigidBody2D.velocity = fallright;
        else rigidBody2D.velocity = fallleft;
     
        move = Time.deltaTime * rand; 
        
        Destroy(gameObject, 4.5f);  
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody2D.rotation += 1.0f;
        //if(rand%2 == 0) transform.Translate(move * fallright, Space.World); 
        //else transform.Translate(move * fallleft, Space.World);
    }
}
