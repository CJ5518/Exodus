using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public UIInventory inventoryUI;

    public static float Maxhealth = 50;
    public static float Curhealth = 40;
    private void Start()
    {
        GiveItem("Health Potion");
        GiveItem("Gold Coin");
        GiveItem("Mana Potion");
        GiveItem("Regular Key");
        GiveItem("Health Pendant");
        inventoryUI.gameObject.SetActive(false);
        Debug.Log("Current Health " + Curhealth);
        Debug.Log("Max Health " + Maxhealth);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) //Open Inventory
        {
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.H)) //Use a health potion
        {
            UsePot("Health Potion");
        }

        if (Input.GetKeyDown(KeyCode.U)) //Use health pendant
        {
            checkHealthPendant("Health Pendant");
        }
    }
    //Add item to inventory based on item name
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

    public void UsePot(string itemName)
    {
        Item itemToRemove = CheckforItemStr(itemName);
        if (itemToRemove != null) //Can be removed
        {
            characterItems.Remove(itemToRemove); //Remove potion from inventory (list object)
            Curhealth += 10; //Add to current health
            inventoryUI.RemoveItem(itemToRemove); //Remove potion from inventory (UI, when player presses I)
            Debug.Log("Item removed: " + itemToRemove.title);
            Debug.Log("Current Health " + Curhealth);
        }
        else
        {
            Debug.Log("No health potion in inventory");
        }
    }

    public void checkHealthPendant(string itemName)
    {
        Item itemToRemove = CheckforItemStr(itemName);
        if (itemToRemove != null) //Can be removed
        {
            characterItems.Remove(itemToRemove); //Remove pendant from inventory (list object)
            Maxhealth += 10; //Add to current health
            inventoryUI.RemoveItem(itemToRemove); //Remove potion from inventory (UI, when player presses I)
            Debug.Log("Item removed: " + itemToRemove.title);
            Debug.Log("Max Health " + Maxhealth);
        }
    }
}
