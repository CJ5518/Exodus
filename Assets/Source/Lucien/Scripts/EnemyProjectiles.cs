using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cj;

//this script has the logic for how the enemy will shoot their ranged projectiles
public class EnemyProjectiles : EnemyDamage
{
    [SerializeField]
    private float speed;            //speed at which the projectiles travel
    [SerializeField]
    private float resetTime;        //length of time before the projectiles reset

    private float lifetime;         //how long the arrows remain on the sxcene after they hit something

    private BoxCollider2D colliders;//this gets the collider for the arrow

    private bool hit;               //did the arrow hit?
    private bool direction;         //what direction is the arrow going to fire from?

    //when the arrow is made...
    private void Awake()
    {
        colliders = GetComponent<BoxCollider2D>();
    }

    //this determines where the arrow is being shot to and what direction it should be facing
    public void ActivateProjectile( bool direction)
    {
        hit = false;
        lifetime = 0;
        colliders.enabled = true;
        if(!direction) 
        {
            transform.Rotate(0, 0, 90);
        }
        else
        {
            transform.Rotate(0, 0, 270);
        }
    }

    //update the arrow once per frame
    private void Update()
    {
        //if the arrow hits anything...
        if(hit)
        {
            transform.Translate(0, 0, 0);
            return;
        }
        //moves the arrow
        float movementSpeed = speed * Time.deltaTime;
        if(direction == true)
        {
            transform.Translate(0, movementSpeed, 0);
        }
        else
        {
            transform.Translate(0, movementSpeed, 0);
        }

        //this starts the count for how much longer the arrow sould remain on the scene for
        lifetime += Time.deltaTime;
        if(lifetime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }

    //if the arrow hits something...
    private void OnTriggerEnter2D(Collider2D coll)
    {
        hit = true;
        base.OnTriggerEnter2D(coll);
        //if the arrow hits the player
        if(coll.tag == "Player" || coll.tag == "Weapon")
        {
            gameObject.SetActive(false);

            PlayerSingleton.Player.dealDamage(7);

            //add Noah's plague event to have a 1/3 chance of causing a darkness plague if the player is hit with an arrow
            if(UnityEngine.Random.Range(1,4) % 2 == 0)
            {
                EventManager eventManager = EventManager.Instance;
                eventManager.startEvent(3, 3, 5);
            }

        }
        else
        {
            //this is if the arrow hits a difrferent collider then the player
            coll.transform.Translate(0,0,0);
            StartCoroutine(Despawn());
        }
        colliders.enabled = false;
    }

    //this keeps track of how long the arrow has been on the scene and if it is too long then the arrow is put back into the object pool
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
