using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is the scrip[t for the ranged enemy, it will be able to be called from the object pool for
// implimentation
public class RangedEnemy : MonoBehaviour
{
    //this is for attack parameters
    [SerializeField] 
    private float attackCooldown;       //this will leave time between arrows that are shot
    [SerializeField]
    private float range;                //this is how far the enemy will be able to shoot
    [SerializeField]
    private int damage;                 //this is how much damage the enemy will deal on impact

    //ranged attack
    [SerializeField]
    private Transform firepoint;        //this is where the arrow is fired from 

    //colider parameters
    [SerializeField]
    private float distance;             //this is how far the enemy has to be away to shoot
    private BoxCollider2D boxCollider;  //this is for the collider

    //player layer
    [SerializeField]
    private LayerMask playerLayer;      //this is how th eenemy will know where the player is
    private float cooldownTimer = Mathf.Infinity;   //so the enemy can start to attack immidiatly

    private float direction = -1;       //what is the direction of the enemy/arrow?
    private bool facingLeft = false;    //enemy starts facing the right
    private Transform player;           //finds the position of the player
    private Animator enemyAnim;         //animation for the enemy

    private float health = 100;         //health for the enemy currently
    
    private float lifeTime;         //this is to tell how long the enemy has been dead for
    private float resetTime;        //this is to tell how long the enemy should be dead for before the despawn
    private bool isDead;            //is the enemy dead?

    private ObjectPool objectPool;  //access to the pool of arrows

    private SFXEnemies sfxEnemies;  //sound access

    //called on inistialization of the archer in the scene
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player").transform;
        enemyAnim = GetComponent<Animator>();
        objectPool = FindObjectOfType<ObjectPool>();
        sfxEnemies = FindObjectOfType<SFXEnemies>();
        lifeTime = 0;
        resetTime = 5;
        isDead = false;
    }

    //called once a frame to get the working components of the archer
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //only attack when the player is in sight of the enemy
        if(PlayerInSight() && !isDead)
        {
            if(cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                StartCoroutine(WaitForAnimation());
                RangedAttack();
            }
        }
        flipToPlayer();

        //checks to see if the enemy is dead, if it is it despawns the archer after a little time
        if(isDead)
        {
            lifeTime += Time.deltaTime;
            if(lifeTime >= resetTime)
            {
                Destroy(gameObject, 1);
            }
        }
    }

    //this is where the archer sees the player and fires an arrow at the player
    private void RangedAttack()
    {
        cooldownTimer = 0;
        GameObject obj = objectPool.GetObject();        //gets an arrow from the pool
        obj.transform.position = firepoint.position;
        obj.transform.rotation = Quaternion.identity;
        sfxEnemies.PlayArcherShoot();
        //allows the arrow projectile script to take over
        obj.GetComponent<EnemyProjectiles>().ActivateProjectile(ReturnEnemyArcherDirection());
    }

    //this makes the archer wait for the anination before firing another arrow
    private IEnumerator WaitForAnimation()
    {
        enemyAnim.SetTrigger("AttackAnimation");

        //wait until the animation has finished
        while(enemyAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 2)
        {
            yield return null;
        }

        yield return new WaitForSeconds(4f);
    }

    //this checks to see if the archer can see the player component
    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * distance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }

    //turn the archer to face the side that the player is on
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

    //this flips the archer to face the correct way
    private void flip()
    {
        direction *= -1;
        facingLeft = !facingLeft;
        transform.Rotate(0, 180, 0);
    }

    //this tells the arrow which way it sould be facing(called in the "EnemyProjectiles" script)
    public bool ReturnEnemyArcherDirection()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;
        if (distanceFromPlayer < 0 && facingLeft)
        {
            return facingLeft;
        }
        else if(distanceFromPlayer > 0 && !facingLeft)
        {
            return !facingLeft;
        }
        return facingLeft;
    }

    //this checks to see if the player hit the enemy, if it did then the archer will take damage
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Weapon")
        {
            //change the health and check if the archer is dead
            health = health - 100;
            PlayerSingleton.Player.onEnemyHit();
            if(health > 0){
                Debug.Log("Health is currently: " + health);
                sfxEnemies.PlayArcherDeath();
            }
            else
            {
                Debug.Log("The ranged enemy is dead...");
                sfxEnemies.PlayArcherDeath();
                isDead = true;
                enemyAnim.SetBool("isDead", isDead);
                //Destroy(gameObject, 1);
            }
        }
    }
}
