using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpAttack : MonoBehaviour
{
    //these are for patrolling the platform.
    [SerializeField]
    float moveSpeed;
    private float direction = -1;
    private bool facingLeft = true;
    [SerializeField]
    Transform GroundCheckPoint;         //see if the enemy is on the ground
    [SerializeField]
    Transform WallCheckPoint;           //see if the enemy is touching a wall
    [SerializeField]
    float circleRadius;
    [SerializeField]
    LayerMask groundLayer;              //this is a layer mask to see if the player is on the ground
    private bool checkGround;
    private bool checkWall;

    //this if for the attacks
    [SerializeField]
    float jumpHeight;
    [SerializeField]
    Transform JumpCheck;
    [SerializeField]
    Transform player;
    [SerializeField]
    Vector2 boxSize;
    private bool touchingGround;

    //this is to find the player
    [SerializeField]
    Vector2 lineOfSight;
    [SerializeField]
    LayerMask playerSee;
    private bool canSeePalyer;

    private float health = 100;
    private bool isDead;

    private LightBanditPool lightBanditPool;

    //other aspects of the base enemy
    private Rigidbody2D enemyRigid;
    private Animator enemyAnim;

    // Start is called before the first frame update
    private void Start()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        enemyAnim = GetComponent<Animator>();
        lightBanditPool = FindObjectOfType<LightBanditPool>();
        isDead = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        checkGround = Physics2D.OverlapCircle(GroundCheckPoint.position, circleRadius, groundLayer);
        checkWall = Physics2D.OverlapCircle(WallCheckPoint.position, circleRadius, groundLayer);
        touchingGround = Physics2D.OverlapBox(JumpCheck.position, boxSize, 0, groundLayer);
        canSeePalyer = Physics2D.OverlapBox(transform.position, lineOfSight, 0, playerSee);
        AnimationControl();
        if(health > 0)
        {
            if(!canSeePalyer && touchingGround)
            {
                patrol();
            }
            else if(canSeePalyer && touchingGround)
            {
                jumpAttack();
            }
        }
        else
        {
            if(CheckIfMeleeEnemyIsDead())
            {
                isDead = true;
                enemyAnim.SetBool("isDead", isDead);
                DeathWait();
                lightBanditPool.ReleaseMeleeObject(gameObject);
            }
        }
    }

    private void patrol()
    {
        if(!checkGround || checkWall)
        {
            if(facingLeft)
            {
                flip();
            }
            else if(!facingLeft)
            {
                flip();
            }
        }
        enemyRigid.velocity = new Vector2(moveSpeed * direction, enemyRigid.velocity.y);
    }

    private void jumpAttack()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;

        if(touchingGround)
        {
            enemyRigid.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void flipToPlayer()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;
        if (distanceFromPlayer < 0 && facingLeft)
        {
            flip();
        }
        else if(distanceFromPlayer > 0 && !facingLeft)
        {
            flip();
        }
    }

    private void flip()
    {
        direction *= -1;
        facingLeft = !facingLeft;
        transform.Rotate(0, 180, 0);
    }

    public bool CheckIfMeleeEnemyIsDead()
    {
        if(health > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "Player")
        {
            health = health - 10;
            if(health > 0){
                Debug.Log("Health is currently: " + health);
            }
            else
            {
                Debug.Log("The melee enemy is dead...");
                DeathWait();
            }
        }
    }
    
    private IEnumerator DeathWait()
    {
        yield return new WaitForSeconds(5);
        enemyAnim.SetBool("isDead", isDead);
        lightBanditPool.ReleaseMeleeObject(gameObject);
        yield return new WaitForSeconds(5);
    }

    private void AnimationControl()
    {
        enemyAnim.SetBool("canSeePlayer", canSeePalyer);
        enemyAnim.SetBool("Grounded", touchingGround);
        enemyAnim.SetBool("isDead", isDead);
    }

}
