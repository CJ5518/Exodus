using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupCoin : MonoBehaviour
{

    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
         inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collected Coin");
        if(collision.tag == "Player")
        {
            inventory.GiveItem("Gold Coin");
            Destroy(gameObject);
        }
    }
}
