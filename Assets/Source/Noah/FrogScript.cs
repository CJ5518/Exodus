using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FrogScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private int direction;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        //flip = GetComponent<SpriteRenderer>().flipX;
        FrogBehavior();
    }

    // Update is called once per frame
    void Update()
    {
         if(player.GetComponent<Rigidbody2D>().transform.position.x < transform.position.x) 
             GetComponent<SpriteRenderer>().flipX = false;
         else
             GetComponent<SpriteRenderer>().flipX = true;
    }
   
    IEnumerator FrogBehavior(){
       while(true){
           yield return new WaitForSeconds(5);
           if(GetComponent<SpriteRenderer>().flipX == false)
               direction = -5;
           else
               direction = 5;
           rb.velocity = new Vector2(direction, 5);
       }
    }
}
