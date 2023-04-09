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
    private Transform firepoint;        

    //colider parameters
    [SerializeField]
    private float distance;             //this is how far the enemy has to be away to shoot
    private BoxCollider2D boxCollider;  //this is for the collider

    //player layer
    [SerializeField]
    private LayerMask playerLayer;      //this is how th eenemy will know where the player is
    private float cooldownTimer = Mathf.Infinity;   //so the enemy can start to attack immidiatly

    private float direction = -1;
    private bool facingLeft = false;
    private Transform player;
    private Animator enemyAnim;

    private float health = 100;

    private ObjectPool objectPool;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player").transform;
        enemyAnim = GetComponent<Animator>();
        objectPool = FindObjectOfType<ObjectPool>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //only attack when the player is in sight of the enemy
        //AnimationControl();
        if(PlayerInSight())
        {
            if(cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                StartCoroutine(WaitForAnimation());
                RangedAttack();
            }
        }
        flipToPlayer();
    }

    private void RangedAttack()
    {
        cooldownTimer = 0;
        GameObject obj = objectPool.GetObject();
        obj.transform.position = firepoint.position;
        obj.transform.rotation = Quaternion.identity;
        //obj.transform.Rotate(0f, 0f, 90f);
        //trouble with the rotation of the arrows here
        obj.GetComponent<EnemyProjectiles>().ActivateProjectile(ReturnEnemyArcherDirection());
    }

    private IEnumerator WaitForAnimation()
    {
        enemyAnim.SetTrigger("AttackAnimation");

        //wait until the animation has finished
        while(enemyAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 2)
        {
            yield return null;
        }
        //RangedAttack();

        yield return new WaitForSeconds(4f);
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * distance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
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
                Debug.Log("The ranged enemy is dead...");
                Destroy(gameObject, 1);
            }
        }
    }

    private void AnimationControl()
    {
        //enemyAnim.SetBool("PlayerInSight", PlayerInSight());
    }
}
