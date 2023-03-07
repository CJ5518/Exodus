using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public UIInventory inventoryUI;
    private void Start()
    {
        GiveItem("Health Potion");
        GiveItem("Gold Coin");
        GiveItem("Mana Potion");
        GiveItem("Regular Key");
        GiveItem("Health Pendant");
        RemoveItemStr("Health Potion");
        Debug.Log("empty slot: " + characterItems[0]);
        inventoryUI.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        }
    }
    public void GiveItem(string itemName)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added item: " + itemToAdd.title);
    }

    //Helper function for remove item to check if said item is in inventory otherwise don't remove
    public Item CheckforItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }

    public Item CheckforItemStr(string title)
    {
        return characterItems.Find(item => item.title == title);
    }

    //Function to remove an item in the character's inventory
    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckforItem(id);
        if (itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove);
            Debug.Log("Item removed: " + itemToRemove.title);
        }
    }

    public void RemoveItemStr(string itemName)
    {
        Item itemToRemove = CheckforItemStr(itemName);
        if (itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove);
            Debug.Log("Item removed: " + itemToRemove.title);
        }
    }
}
