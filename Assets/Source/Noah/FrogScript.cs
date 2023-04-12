using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FrogScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private int direction;
    private float jumpTimer;
    private int speedX;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        speedX = 8; //this is a good default jump speed in x direction // comment this line for stress test
        jumpTimer = 4;
    }

    public void receiveSpeed(int speed){
        speedX = speed;
        //Debug.Log("received: "+speedX);
    }

    // Update is called once per frame
    void Update()
    {Debug.Log("speedX: "+speedX);
         if(player.GetComponent<Rigidbody2D>().transform.position.x < transform.position.x) {
             GetComponent<SpriteRenderer>().flipX = false;
             direction = 0 - speedX;
         }
         else {
             GetComponent<SpriteRenderer>().flipX = true;
             direction = speedX;
         }
         //Debug.Log("speedX: "+speedX);
         jumpTimer += Time.deltaTime;
         if (jumpTimer >= 5.0f){
             //Debug.Log("direction: "+direction);
             rb.velocity = new Vector2(direction, 8);
             jumpTimer = 0;
         }
    }

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag == "Player"){
            //damage the player
            Destroy(gameObject, 0f);
        }
    }

}
