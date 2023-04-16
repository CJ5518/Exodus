using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using cj;

public class FrogScript : MonoBehaviour
{
    private GameObject player;
    private int direction;
    private float jumpTimer;
    private static int nextJump;
    private int speedX;

    private float prevYVel;
    private Rigidbody2D rb;
    private Sprite airSprite, groundSprite;
   
    // Start is called before the first frame update
    void Start()
    {
        airSprite = Resources.Load<Sprite>("prefabs\\Noah\\sprites\\f_air_good");
        groundSprite = Resources.Load<Sprite>("prefabs\\Noah\\sprites\\f_ground_good");
        Debug.Log("airSPite:  "+airSprite);Debug.Log("groundSprite:  "+groundSprite);
        rb = GetComponent<Rigidbody2D>();
        prevYVel = 1f;
        player = GameObject.FindWithTag("Player");
        speedX = 12; //this is a good default jump speed in x direction // comment this line for stress test
        jumpTimer = 4;
    }

    public void receiveSpeed(int speed){
        speedX = speed;
        //Debug.Log("received: "+speedX);
    }

    // Update is called once per frame
    void Update()
    {    
         //face the frog towards the player
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
         if (jumpTimer >= (float)nextJump){
             GetComponent<SpriteRenderer>().sprite = airSprite;
             //Debug.Log("direction: "+direction);
             rb.velocity = new Vector2(direction, 8);
             jumpTimer = 0;
             nextJump = UnityEngine.Random.Range(2, 6);
         }
         // the frog slides on the ground after a jump, so I will set x.velocity to 0 when it lands
         // I also use this logic to change the sprite to make it look like its jumping when its in air
         if(prevYVel == 0 && rb.velocity.y == 0)
         {
             GetComponent<SpriteRenderer>().sprite = groundSprite;
             rb.velocity = Vector2.zero;
         }
         prevYVel = rb.velocity.y;
    }

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag == "Player"){
            //damage the player
            PlayerSingleton.Player.dealDamage(10);

            Destroy(gameObject, 0f);
        }
    }

}


