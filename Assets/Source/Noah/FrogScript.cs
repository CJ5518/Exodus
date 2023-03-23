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
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        jumpTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
         if(player.GetComponent<Rigidbody2D>().transform.position.x < transform.position.x) {
             GetComponent<SpriteRenderer>().flipX = false;
             direction = -5;
         }
         else {
             GetComponent<SpriteRenderer>().flipX = true;
             direction = 5;
         }
         jumpTimer += Time.deltaTime;
         if (jumpTimer >= 5.0f){
             rb.velocity = new Vector2(direction, 5);
             jumpTimer = 0;
         }
    }
  
}
