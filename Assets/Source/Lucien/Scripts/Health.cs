using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this would have controlled the health of all the enemies but I was having trouble with the call to this from the object pool enemies
//so this is not implimented
public class Health : MonoBehaviour
{
   [SerializeField]
   private float startingHealth;        //this is the starting health that the enemy has
   public float currentHealth { get; private set; } //this gets the current health of the enemy
   private bool dead;                   //this tells if the enemy is dead or not
   private SpriteRenderer sprite;       //this loads the current sprite

   //invulnerabliity
   [SerializeField]
   private float iFrames;
   [SerializeField]
   private int numberOfFrames;

   //this is for anything that may be attached to the enemy
   [SerializeField]
   private Behaviour[] components;
   private bool invulnerable;

   private void Awake()
   {
    currentHealth = startingHealth;
    dead = false;
    sprite = GetComponent<SpriteRenderer>();
   }

   public void EnemyTakeDamage(float damageTaken)
   {
    if(invulnerable) return;
    currentHealth = Mathf.Clamp(currentHealth - damageTaken, 0, startingHealth);

    if(currentHealth > 0)
    {
        //this will change the animation to hurt
        StartCoroutine(Invunerability());
    }else 
    {
        if(!dead)
        {
            //set the death animation
            foreach(Behaviour component in components)
            {
                component.enabled = false;
            }
            dead = true;
        }
    }
   }

   public bool CheckIfDead()
   {
        if(dead == false)
        {
            return false;
        }else 
        {
            return true;
        }
   }

   private IEnumerator Invunerability()
   {
    invulnerable = true;
    Physics2D.IgnoreLayerCollision(10, 11, true);
    for(int i = 0; i < numberOfFrames; i++)
    {
        yield return new WaitForSeconds(iFrames / (numberOfFrames * 2));
    }
    Physics2D.IgnoreLayerCollision(10, 11, false);
    invulnerable = false;
   }
}
