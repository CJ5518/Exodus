using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupCoin : MonoBehaviour
{
    Inventory inventory;
    CoinCollect ScoreManager;
    //CoinCollect coinCollect;

    // Start is called before the first frame update
    void Start()
    {
         inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
         ScoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<CoinCollect>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collected Coin");
        if(collision.tag == "Player")
        {
            inventory.GiveItem("Gold Coin");
            
            ScoreManager.CoinCollected();
            Debug.Log("Coin picked up");
            Destroy(gameObject);
        }
    }

}
