using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
