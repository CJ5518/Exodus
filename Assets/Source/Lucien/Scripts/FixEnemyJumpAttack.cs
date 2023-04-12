using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixEnemyJumpAttack : JumpAttack
{   
    private bool hasRun = false;
    public override void jumpAttack( float jump, Rigidbody2D enemyRigid, bool touchingGround)
    {
        Transform player = GameObject.Find("Player").transform;
        float distanceFromPlayer = player.position.x - transform.position.x;

            if(touchingGround)
            {
                enemyRigid.AddForce(new Vector2(distanceFromPlayer, jump), ForceMode2D.Impulse);
                hasRun = false;
            }
            
            if(!touchingGround && !hasRun)
            {
                if(distanceFromPlayer < 3.8)
                {
                    //this will give the enemy a slight bump back to reset the enemy
                    enemyRigid.AddForce(new Vector2(-20, 1), ForceMode2D.Impulse);
                    hasRun = true;
                }
            }
            
    }
}
