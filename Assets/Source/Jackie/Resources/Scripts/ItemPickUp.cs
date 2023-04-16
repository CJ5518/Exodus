using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemPickUp : MonoBehaviour
{
    Inventory inventory;
    public PotionPool potionPool;



    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inventory.GiveItem("Health Potion");
            potionPool.ReleaseObject(gameObject);
        }
    }
}
