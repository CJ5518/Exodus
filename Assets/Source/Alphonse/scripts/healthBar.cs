using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Image health;
    public GameObject boss;
    public float healthAmt = 100f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            healthAmt -= 50f;
            health.fillAmount = healthAmt / 100f;
        }

        if(healthAmt == 0)
        {
            Destroy(boss);
        }
    }
}
