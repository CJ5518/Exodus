using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is for the Melee enemy and allows it to do all the different behaviors such as jump, attack, and take damage
public class EnemyJumpAttack : MonoBehaviour
{
    //these are for patrolling the platform.
    [SerializeField]
    float moveSpeed;                    //this is how fast the enemy moves on the scene
    private float direction = -1;       //this gets the current direction that the enemy is facing
    private bool facingLeft = true;     //the enemy spawns in facing to the left direction
    [SerializeField]
    Transform GroundCheckPoint;         //see if the enemy is on the ground
    [SerializeField]
    Transform WallCheckPoint;           //see if the enemy is touching a wall
    [SerializeField]
    float circleRadius;                 //This is how big the circle radius of the previous two transform objects is
    [SerializeField]
    LayerMask groundLayer;              //this is a layer mask to see if the player is on the ground
    private bool checkGround;           //is the enemy currently on the ground?
    private bool checkWall;             //is the enemy currently hitting a wall or a different enemy?

    //this if for the attacks
    [SerializeField]
    float jumpHeight;                   //this is how high the enemy is able to jump
    [SerializeField]
    Transform JumpCheck;                //this is the attempted corrdinates that the enemy is jumping to
    [SerializeField]
    Transform player;                   //this gets the current location of the player so the enemy knows where the target jump location is
    [SerializeField]
    Vector2 boxSize;                    //this is another check for in the enemy is currently on the ground or not, ie the size of the check object
    private bool touchingGround;        //is the enemy currently on the ground?

    //this is to find the player
    [SerializeField]
    Vector2 lineOfSight;                //checks to see if the enemy will recognize the player at a set distance
    [SerializeField]
    LayerMask playerSee;                //checks to see if the enemy can see the player in the scene (enemy will not function without the player in the scene)
    private bool canSeePalyer;          //can the enemy "see" the player currently?

    private float health = 100;         //this is the total health of the enemy
    private bool isDead;                //is the enemy dead or alive?

    private LightBanditPool lightBanditPool;    //refrence to the objectpool that the melee enemy is stored in

    public JumpAttack jumpAttackScript;         // this is the refrence to the script that holds the static and dynamic functions (virtual/override)

    private float lifeTime;             //this is so the enemy despawns after a while when it is killed...
    private float resetTime;            //this is so the enemy is only in the scene dead for so long...
    //other aspects of the base enemy
    private Rigidbody2D enemyRigid;     //this is the rigidbody that is attacked to the enemy
    private Animator enemyAnim;         //this is the animation effects for the melee enemy
    private SFXEnemies sfxEnemies;      //this is where the cound effects reside

    private bool hasJumped;             //this will tell us if the bandt has jumped before he has swung his sword
    private float waitForAttack;        //this will be how we let the light bandit attack again
    private float waitForAttackAnimation; //this will let us wait for the animation to finish for the script to continue

    // Start is called before the first frame update
    private void Start()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        enemyAnim = GetComponent<Animator>();
        lightBanditPool = FindObjectOfType<LightBanditPool>();
        isDead = false;
        health = 100;
        sfxEnemies = FindObjectOfType<SFXEnemies>();
        lifeTime = 0;
        resetTime = 5;
        hasJumped = false;
        //these will be used to the enemy isn't infinetly attacking...
        waitForAttack = 0;      //wait one second for attack
        waitForAttackAnimation = 0; //give 2 seconds after the npc has attacked to continue
    }

    // Fixed update is called instead of update so the functions aren't called as many times as they usually are in
    //an Update function (makes the game run smoother)
    private void FixedUpdate()
    {
        checkGround = Physics2D.OverlapCircle(GroundCheckPoint.position, circleRadius, groundLayer);
        checkWall = Physics2D.OverlapCircle(WallCheckPoint.position, circleRadius, groundLayer);
        touchingGround = Physics2D.OverlapBox(JumpCheck.position, boxSize, 0, groundLayer);
        canSeePalyer = Physics2D.OverlapBox(transform.position, lineOfSight, 0, playerSee);
        AnimationControl();
        enemyAnim.SetBool("attack", hasJumped);

        //make sure enemy isn't dead
        if(health > 0)
        {
            if(!canSeePalyer && touchingGround)
            {
                //this is if the player is out of enemy range, and the enemy is currently on the ground
                patrol();
            }
            else if(canSeePalyer && touchingGround)
            {
                //the enemy attacks the player once it gets in range
                jumpAttackScript.jumpAttack(jumpHeight, enemyRigid, touchingGround);
                hasJumped = true;
                enemyAnim.SetBool("attack", hasJumped);
                swordAttack();
            }
            else if(!touchingGround && canSeePalyer)
            {
                //this is the recovery of the enemy after it attacks the player
                jumpAttackScript.jumpAttack(jumpHeight, enemyRigid, touchingGround);
                hasJumped = true;
                enemyAnim.SetBool("attack", hasJumped);
                swordAttack();
            }
        } 
        else
        {
            //the enemy is dead and can be called off of the scene via objectpool
            if(CheckIfMeleeEnemyIsDead(health))
            {
                //this just changes the animation
                isDead = true;
                enemyAnim.SetBool("isDead", isDead);
                DeathWait();
                //lightBanditPool.ReleaseMeleeObject(gameObject);
            }
        }

        //this will get rid of the enemy off the scene and store it in the object pool once again
        if(isDead)
        {
            lifeTime += Time.deltaTime;
            if(lifeTime >= resetTime)
            {
                lightBanditPool.ReleaseMeleeObject(gameObject);
                cleanUpAfterDespawn();
            }
        }
    }

    //enemy walks back and forth on the platform while waiting for the player
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

    //the enemy will swing its sword at the player upon attack call
    private void swordAttack()
    {
        //enemyIsAttacking = true;
        if(waitForAttack > 1)
        {
            enemyAnim.SetBool("attack", hasJumped);
            waitForAttackAnimation += Time.deltaTime;
        }
        if(waitForAttack > 1 && waitForAttackAnimation > 2.5)
        {
            hasJumped = false;
            enemyAnim.SetBool("attack", hasJumped);
            //enemyIsAttacking = false;
        }
        hasJumped = false;
    }

    //if the enemy is close enough to the player on attack then the player will take damage from the enemy
    private void enemyDealsPlayerDamage()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;
        if(distanceFromPlayer < 4)
        {
            PlayerSingleton.Player.dealDamage(5);
        }
    }

    //this allows the enemy to change direction to face the player
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

    //this flips the enemy to face the other direction
    private void flip()
    {
        direction *= -1;
        facingLeft = !facingLeft;
        transform.Rotate(0, 180, 0);
    }

    //this is used as a check to see if the melee enemy is dead or not
    public bool CheckIfMeleeEnemyIsDead( float health1)
    {
        if(health1 > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //this is how the enemy takes damage form the player and eventually dies
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "Weapon")
        {
            health = health - 100;
            if(health > 0){
                Debug.Log("Health is currently: " + health);
                sfxEnemies.PlayBanditDeath();
            }
            else
            {
                Debug.Log("The melee enemy is dead...");
                sfxEnemies.PlayBanditDeath();
                enemyAnim.SetBool("isDead", isDead);
                DeathWait();
            }
            //if(enemyIsAttacking == true)
            //{
                //PlayerSingleton.Player.dealDamage(10);
            //}
        }
    }
    
    //allows time for the enemy to change animation and wait on the scene for a while before despawn
    private IEnumerator DeathWait()
    {
        yield return new WaitForSeconds(1);
        enemyAnim.SetBool("isDead", isDead);
        lightBanditPool.ReleaseMeleeObject(gameObject);
        cleanUpAfterDespawn();
        yield return new WaitForSeconds(1);
    }

    //controlls the animations for the enemy(is called in FixedUpdate())
    private void AnimationControl()
    {
        enemyAnim.SetBool("canSeePlayer", canSeePalyer);
        enemyAnim.SetBool("Grounded", touchingGround);
        enemyAnim.SetBool("isDead", isDead);
    }

    //this will reinmitialize all the values in the script to default
    public void cleanUpAfterDespawn()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        enemyAnim = GetComponent<Animator>();
        lightBanditPool = FindObjectOfType<LightBanditPool>();
        isDead = false;
        health = 100;
        sfxEnemies = FindObjectOfType<SFXEnemies>();
        lifeTime = 0;
        resetTime = 5;
        hasJumped = false;
        //these will be used to the enemy isn't infinetly attacking...
        waitForAttack = 0;      //wait one second for attack
        waitForAttackAnimation = 0; //give 2 seconds after the npc has attacked to continue
    }
}
