using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is not used in current implimentation due to the way that the enemy was instansiated
//I figured that it would be better to use these scripts in a different way then previously
//As this script had a poorly thought out implimentation...
public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    protected float damage;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>()?.EnemyTakeDamage(damage);
        }
    }
}
