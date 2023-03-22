using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script has the logic for how the enemy will shoot their ranged projectiles

public class EnemyProjectiles : EnemyDamage
{
    [SerializeField]
    private float speed;            //speed at which the projectiles travel
    [SerializeField]
    private float resetTime;        //length of time before the projectiles reset

    private float lifetime;

    private Transform enemy;

    private BoxCollider2D colliders;
    private RangedEnemy rangedEnemy;

    private bool hit;
    private bool direction;

    private void Awake()
    {
        colliders = GetComponent<BoxCollider2D>();
        enemy = GameObject.Find("Archer").transform;
        rangedEnemy = GameObject.Find("Archer").AddComponent<RangedEnemy>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        colliders.enabled = true;
        direction = rangedEnemy.ReturnEnemyArcherDirection();
        if(!direction)
        {
            transform.Rotate(0, 0, 90);
        }
        else
        {
            transform.Rotate(0, 0, 270);
        }
    }

    private void Update()
    {
        if(hit)
        {
            transform.Translate(0, 0, 0);
            return;
        }
        float movementSpeed = speed * Time.deltaTime;
        if(direction == true)
        {
            transform.Translate(0, movementSpeed, 0);
        }
        else
        {
            transform.Translate(0, movementSpeed, 0);
        }

        lifetime += Time.deltaTime;
        if(lifetime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        hit = true;
        base.OnTriggerEnter2D(coll);
        if(coll.tag == "Player")
        {
            gameObject.SetActive(false);
        }else
        {
            coll.transform.Translate(0,0,0);
            StartCoroutine(Despawn());
        }
        colliders.enabled = false;
    }

    private IEnumerator Despawn()
    {
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(5);
            gameObject.SetActive(false);
            yield return new WaitForSeconds(5);
        }
    }

}
