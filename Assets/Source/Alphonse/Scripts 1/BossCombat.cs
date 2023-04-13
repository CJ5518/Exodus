using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = .5f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Attack();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
           Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] objectsHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

        foreach(Collider2D playerObject in objectsHit)
        {
            Debug.Log("We hit " + playerObject.name);
            //playerObject.GetComponent<Player>.TakeDamage();  place a var with an int to assign danage to the player
        }
    }
    void OnDrawGizmosSelected() {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
