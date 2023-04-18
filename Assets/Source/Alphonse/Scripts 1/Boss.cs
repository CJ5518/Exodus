using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossPattern1.Decorator;
using cj;

public class Boss : singletonBoss<Boss>
{
    private Rigidbody2D bossRB;
    private Collider2D bossBodyCollider;
    private Collider2D bossBaseCollider;
    private MeleeAttack attack;
    public BossHealth bossHealth;
    public GameObject boss;
    private Transform player;

    //public float currentHealth;
    //var mummyMelee = new Melee();
    BossAttack mAttack = null;
    int damage;
    

    public float bossSpeed;

    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        bossHealth = boss.GetComponent<BossHealth>();
        //mummyMelee = new Melee();
        //MeleeAttack mAttack = new baseMelee();
        mAttack = new Melee();
        damage = mAttack.Damage;
        Debug.Log("1) mAttack: " + damage.ToString());

    }

    public static void bossLevel_1()
    {
        
        //currentHealth = boss.healthAmt;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(mAttack != null){
            mAttack = new runMeleeAttack(mAttack);
            damage = mAttack.Damage;
        }

        

        if (other.collider.tag == "Player")
        {
            if (bossHealth.healthAmt > 50)
            {

                Debug.Log("X mAttack: " + (mAttack.Damage).ToString());
                PlayerSingleton.Player.dealDamage(damage);
                //PlayerSingleton.Player.dealDamage(10);

            }
            else
            {
                mAttack = new damageBoost(mAttack);
                Debug.Log("Y mAttack: " + (mAttack.getDamage()));

                PlayerSingleton.Player.dealDamage(mAttack.getDamage());
            }
        }
    }
    /*
private void OnCollisionEnter2D(Collision2D other)
{
    var mummyMelee = new Melee();
    MeleeAttack mAttack = new runMeleeAttack(mummyMelee);

    if (other.collider.tag == "Player")
    {
        if (bossHealth.healthAmt > 50)
        {
            int x = mAttack.Damage;
            Debug.Log("mAttack: " + x);
            PlayerSingleton.Player.dealDamage(mAttack.Damage);
        }
        else
        {
            mAttack = new damageBoost(mAttack);
            Debug.Log("mAttack: " + mAttack);

            PlayerSingleton.Player.dealDamage(mAttack.Damage);
        }
    }
}*/

    /* public BossAttack ma
     {
         get
         {
             Debug.Log(bossAttacks);
             return bossAttacks;
         }
         set
         {
             bossAttacks  = value;
         }
     }
     */
}
