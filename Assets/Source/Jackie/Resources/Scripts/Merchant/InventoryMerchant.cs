using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMerchant : MonoBehaviour
{
    public List<ItemMerchant> merchantItems = new List<ItemMerchant>();
    public ItemDatabaseMerchant itemDatabaseMerchant;

    public UIInventoryMerchant inventoryUIMerchant;
    Inventory inventory;
    bool inventoryOpen = true;

    private void Start()
    {
        GiveItem("Jump Pendant");
        GiveItem("Health Potion");
        GiveItem("Speed Pendant");
        GiveItem("Regular Key");
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        inventoryUIMerchant.gameObject.SetActive(true);
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.M)) //Open Merchant Inventory (Should not be used in final implementatiobn)
        // {
        //     inventoryUIMerchant.gameObject.SetActive(!inventoryUIMerchant.gameObject.activeSelf);
        //     if (inventoryOpen == false)
        //     {
        //         Debug.Log("Merchant is now open");
        //         inventoryOpen = true;
        //     }
        //     else
        //     {
        //         Debug.Log("Merchant is now closed");
        //         inventoryOpen = false;
        //     }
        // }

        if (Input.GetKeyDown(KeyCode.F) & inventoryOpen == true) //Buy First Item
        {
            if (inventory.RemoveItemStr("Gold Coin") == true)
            {
                inventory.GiveItem("Jump Pendant");
                RemoveItemStr("Jump Pendant");
            }
            else
            {
                Debug.Log("No coin in inventory");
            }
        }

        
        if (Input.GetKeyDown(KeyCode.G) & inventoryOpen == true) //Buy Second Item
        {
            if (inventory.RemoveItemStr("Gold Coin") == true)
            {
                inventory.GiveItem("Health Potion"); //Give player
                RemoveItemStr("Health Potion"); //Remove from merchant
            }
            else
            {
                Debug.Log("No coin in inventory");
            }
        }

        
        if (Input.GetKeyDown(KeyCode.V) & inventoryOpen == true) //Buy Third Item
        {
            if (inventory.RemoveItemStr("Gold Coin") == true)
            {
                inventory.GiveItem("Speed Pendant");
                RemoveItemStr("Speed Pendant");
            }
            else
            {
                Debug.Log("No coin in inventory");
            }
        }

        
        if (Input.GetKeyDown(KeyCode.B) & inventoryOpen == true) //Buy Fourth Item
        {
            if (inventory.RemoveItemStr("Gold Coin") == true)
            {
                inventory.GiveItem("Regular Key");
                RemoveItemStr("Regular Key");
            }
            else
            {
                Debug.Log("No coin in inventory");
            }
        }
    }

    public void GiveItem(string itemName)
    {
        ItemMerchant itemToAdd = itemDatabaseMerchant.GetItem(itemName);
        merchantItems.Add(itemToAdd);
        inventoryUIMerchant.AddNewItem(itemToAdd);
        Debug.Log("Added item to Merchant: " + itemToAdd.title);
    }


    public ItemMerchant CheckforItemStr(string title)
    {
        return merchantItems.Find(item => item.title == title);
    }

    public bool RemoveItemStr(string itemName)
    {
        bool Removed = false;
        Debug.Log("Entered Remove Item Function of Merchant");
        ItemMerchant itemToRemove = CheckforItemStr(itemName);
        if (itemToRemove != null)
        {
            merchantItems.Remove(itemToRemove);
            inventoryUIMerchant.RemoveItem(itemToRemove);
            Debug.Log("Item removed from merchant: " + itemToRemove.title);
            Removed = true;
        }
        return Removed;
    }
}
