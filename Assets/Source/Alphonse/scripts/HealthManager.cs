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
    public float healthAmt = 100f;
    public float damage = 33.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            takeDamage(damage);
        }
    }

    public void takeDamage(float damage)
    {
        healthAmt -= damage;
        healthBar.fillAmount = healthAmt / 100f;

        if (healthAmt <= 0)
        {
            healthAmt = 0;
            healthBar.fillAmount = healthAmt / 100f;
            Debug.Log("YOU'RE DEAD!");

            isOver = true;
        }
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