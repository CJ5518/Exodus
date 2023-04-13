using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    //public static bool isOver = false;
    //public GameObject GameOverCanvas;
    public Image healthBar; 
    
    [SerializeField]
    public float healthAmt = 100f;

    [SerializeField]
    public float damage = 34f;

    public Animator animator;

    // If the Boss collides with the Player, The boss will take damage to its health.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
           takeDamage(damage);
           healthBar.fillAmount = healthAmt / 100f;
        }
    }

    // Function to decrement the health of the boss(s)
    public void takeDamage(float damage)
    {
        healthAmt = healthAmt - damage;
        animator.SetTrigger("Hurt");

        if (healthAmt <= 0)
        {
            
            healthAmt = 0;
            healthBar.fillAmount = healthAmt / 100f;
            
            dead();
            animator.SetBool("isDead",true);
        }

        if (healthAmt > 100)
        {
            healthAmt = 100;
        }
    }

    private void OnDrawGizmosSelected() 
    {
        {
            Debug.Log("BOSS IS DEAD!");
        }
    }

    void dead()
    {
        

        //this.GetComponent<Renderer>().enabled = false;
        this.GetComponent<CapsuleCollider2D>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;

    }
}