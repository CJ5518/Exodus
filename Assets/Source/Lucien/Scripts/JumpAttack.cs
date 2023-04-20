using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is the superclass for the lunge part of the melee attack.
//if this is called instead of the override function then there will be no enemy bounce back
public class JumpAttack : MonoBehaviour
{
    
    public virtual void jumpAttack(float jump, Rigidbody2D enemyRigid, bool touchingGround)
    {
        Transform player = GameObject.Find("Player").transform;
        float distanceFromPlayer = player.position.x - transform.position.x;

            if(touchingGround)
            {
                enemyRigid.AddForce(new Vector2(distanceFromPlayer, jump), ForceMode2D.Impulse);
            }
    }
}
