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
    public float healthAmt;
    private float MaxHealthAmt;

    [SerializeField]
    public float damage;

    public Animator animator;

    private SFXBoss sfx;

    //public GameObject plagueLoader;
    public EventManager em;
    

    void Start()
    {
        Time.timeScale = 1f;
        MaxHealthAmt = healthAmt;

        sfx = FindObjectOfType<SFXBoss>();
        GetComponent<Animator>().SetBool("isIdle", true);
        
        em = Resources.Load<EventManager>("prefabs/Noah/myEventManager");
    }

    // If the Boss collides with the Player, The boss will take damage to its health.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
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
        sfx.playBossHurt();

        if(healthAmt >= 30 && damage < 10)
        {
            GetComponent<Animator>().SetBool("isIdle", false);
            GetComponent<Animator>().SetBool("isWalking", false);
            GetComponent<Animator>().SetBool("isRunning", true);
            
        } 
        else if( healthAmt <= 60 && damage >= 10)
        {
            GetComponent<Animator>().SetBool("isIdle", false);
            GetComponent<Animator>().SetBool("isRunning", false);
            GetComponent<Animator>().SetBool("isWalking", true);
        }

        if(healthAmt >= 80 && damage >= 10)
        {
            em.startEvent(1, 5, 5);
        }else if((healthAmt >= 21 && healthAmt <= 79) && damage >= 10)
        {
            em.startEvent(1, 8, 5);
        }else if(healthAmt <= 20 && damage >= 10)
        {
            em.startEvent(1, 10, 15);
        }

        if(healthAmt >= 80 && damage < 10)
        {
            em.startEvent(2, 7, 5);
        }else if((healthAmt >= 21 && healthAmt <= 79) && damage < 10)
        {
            em.startEvent(3, 8, 5);
        }else if(healthAmt <= 20 && damage < 10)
        {
            em.startEvent(2, 10, 15);
        }

        if (healthAmt <= 0)
        {
            healthAmt = 0;
            healthBar.fillAmount = healthAmt / MaxHealthAmt;
            
            dead();
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
        animator.SetBool("isDead",true);
        sfx.playBossDeath();

        this.GetComponent<Renderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;

        //Time.timeScale = 0f;
    }
}