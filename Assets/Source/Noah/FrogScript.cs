using System.Collections.Generic;
using UnityEngine;
using System;
using cj;

public class FrogScript : MonoBehaviour
{
    private GameObject player;
    private float jumpTimer;
    private static int nextJump;
    private static int speedX;
    private static int speedY;

    private float prevYVel;
    private int isGrounded;
    private Rigidbody2D rb;
    private Sprite airSprite, groundSprite;
   
    // Start is called before the first frame update
    void Start()
    {
        airSprite = Resources.Load<Sprite>("prefabs\\Noah\\sprites\\f_air_good");
        groundSprite = Resources.Load<Sprite>("prefabs\\Noah\\sprites\\f_ground_good");
   
        //make sure the sprites were loaded from resources
        //Debug.Log("airSprite: " + airSprite + " groundSprite: " + groundSprite);

        //find the rigid body of the frog that this script is attached to
        rb = GetComponent<Rigidbody2D>();

        //initialize the previous Y velocity to not 0, because checks in the update function look for 0
        prevYVel = 1f;
 
        //the frog starts in a not jumping state, although it may be spawned in the air
        isGrounded = 1;

        player = GameObject.FindWithTag("Player");

        jumpTimer = 4;
    }

    public void receiveSpeed(int speed){
        // a higher X speed and lower Y speed will be more difficult for the player
        // speed comes from the specified difficulty, so higher speed parameter means higher difficulty
        
        speedX = speed*3;
       
        // Don't adjust the Y speed as much, because then it won't look like a jump
        speedY = 10 - (int)(speed/2);
        //Debug.Log("received the speed(x,y): ("+speedX+","+speedY+")");
    }

    // Update is called once per frame
    void Update()
    {    
         //face the frog towards the player
         if(player.GetComponent<Rigidbody2D>().transform.position.x < transform.position.x) {
             GetComponent<SpriteRenderer>().flipX = false;
             if(speedX > 0) speedX = 0 - speedX;
         }
         else {
             GetComponent<SpriteRenderer>().flipX = true;
             if(speedX < 0) speedX = 0 - speedX;
         }

         //increment time, and jump if enough time has passed
         jumpTimer += Time.deltaTime;
         if (jumpTimer >= (float)nextJump){
             //"animate" the frog with a jumping sprite
             GetComponent<SpriteRenderer>().sprite = airSprite;
 
             //set the frogs velocity upwards and toward the player and change its state
             //Debug.Log("speed(x,y): ("+speedX+","+speedY+")");
             rb.velocity = new Vector2(speedX, speedY);
             isGrounded = 0;

             //reset the timer and set it to an unpredictable time
             jumpTimer = 0;
             nextJump = UnityEngine.Random.Range(2, 6);
         }
       
         // the frog slides on the ground after a jump, so I will set x.velocity to 0 when it lands
         // Since i use this to detect landing, it can also be used to "animate" the frog
         // the previous frame Y velocity must be checked, otherwise it would stop at the top of the arc
         if(prevYVel == 0 && rb.velocity.y == 0) 
         {
             GetComponent<SpriteRenderer>().sprite = groundSprite;
             rb.velocity = Vector2.zero;
             isGrounded = 1;
         }
         prevYVel = rb.velocity.y;
    }

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag == "Player"){
            //damage the player only if the frog is in it's jump attack (not grounded)
            if(isGrounded == 0) 
                PlayerSingleton.Player.dealDamage(10);

            //despawn the frog
            Destroy(gameObject, 0f);
        }
    }

}



