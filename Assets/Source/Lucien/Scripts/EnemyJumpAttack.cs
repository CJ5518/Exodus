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

    //other aspects of the base enemy
    private Rigidbody2D enemyRigid;
    private Animator enemyAnim;
    private int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkGround = Physics2D.OverlapCircle(GroundCheckPoint.position, circleRadius, groundLayer);
        checkWall = Physics2D.OverlapCircle(WallCheckPoint.position, circleRadius, groundLayer);
        touchingGround = Physics2D.OverlapBox(JumpCheck.position, boxSize, 0, groundLayer);
        canSeePalyer = Physics2D.OverlapBox(transform.position, lineOfSight, 0, playerSee);
        AnimationControl();
        if(!canSeePalyer && touchingGround)
        {
            patrol();
        }
        else if(canSeePalyer && touchingGround)
        {
            jumpAttack();
        }
    }

    void patrol()
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

    void jumpAttack()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;

        if(touchingGround)
        {
            enemyRigid.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
        }
    }

    void flipToPlayer()
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

    void flip()
    {
        direction *= -1;
        facingLeft = !facingLeft;
        transform.Rotate(0, 180, 0);
    }

    void AnimationControl()
    {
        enemyAnim.SetBool("canSeePlayer", canSeePalyer);
        enemyAnim.SetBool("Grounded", touchingGround);
    }

    public int lightBanditTakeDamage(int y, int x)
    {
        y = y - x;
        health = y;
        return health;
    }
}
