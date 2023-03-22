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
    
    private bool isGrounded = false;

    System.Random rnd = new System.Random();
    

    // Start is called before the first frame update
    void Start()
    {
        rand = rnd.Next(2,6);

        rigidBody2D = GetComponent<Rigidbody2D>();
        
        if(rand%2 == 0)rigidBody2D.velocity = fallright;
        else rigidBody2D.velocity = fallleft;
     
        move = Time.deltaTime * rand; 
        
        Destroy(gameObject, 8f);  
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGrounded) rigidBody2D.rotation += 2.0f;
        //if(rand%2 == 0) transform.Translate(move * fallright, Space.World); 
        //else transform.Translate(move * fallleft, Space.World);
    }
    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag != "HailStone"){
          isGrounded = true;
          rigidBody2D.freezeRotation = true;
          Destroy(gameObject, 1f);
        }
    }
}
