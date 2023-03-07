using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public static bool isOver = false;
    //public GameObject GameOverCanvas;
    public Image healthBar;
    
    [SerializeField]
    public float healthAmt = 100f;

    [SerializeField]
    public float damage = 34f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            takeDamage(damage);
            healthBar.fillAmount = healthAmt / 100f;
        }
    }

    public void takeDamage(float damage)
    {
        healthAmt = healthAmt - damage;
        

        if (healthAmt <= 0)
        {
            healthAmt = 0;
            //healthBar.fillAmount = healthAmt / 100f;
            Debug.Log("YOU'RE DEAD!");

            isOver = true;

            //int healthReturn = (int)healthAmt;
            //return healthReturn;
        }
        

        //return 0;
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmt = 100f;
    // Start is called before the first frame update
    private void Start()
    {
        healthAmt = 100f;
    }

    // Update is called once per frame

    public void TakeDamage(float damage)
    {
        healthAmt -= damage;
        healthBar.fillAmount = healthAmt / 100f;

        if(healthAmt <= 0)
        {
            healthAmt = 0;
            Debug.Log("YOU'RE DEAD!");
        }
    }

}*/