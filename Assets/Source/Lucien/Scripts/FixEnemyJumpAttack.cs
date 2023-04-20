using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is called when the melee enemy lunges at the player in the game.
//if the enemy is too close after they lunge at the player then they are bounced back
public class FixEnemyJumpAttack : JumpAttack
{   
    private bool hasRun = false;    //ensures that the bounce bakc part of the script is called
    
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
                if(distanceFromPlayer < 4.5)
                {
                    //this will give the enemy a slight bump back to reset the enemy
                    enemyRigid.AddForce(new Vector2(-distanceFromPlayer * 4, 1), ForceMode2D.Impulse);
                    hasRun = true;
                }
            }
            
    }
}
