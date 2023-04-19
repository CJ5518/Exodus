using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup_Key : MonoBehaviour
{
    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
         inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collected Key");
        if(collision.tag == "Player")
        {
            inventory.GiveItem("Regular Key");
            Destroy(gameObject);
        }
    }
}
