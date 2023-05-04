using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using cj;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public UIInventory inventoryUI;

    private GameObject playerObj = null;

    private GameObject player;
    public GameObject HealthPotPrefab;
    bool inventoryOpen = false;
    
    public AudioSource Drink;
    public AudioSource MenuOpen;
    public AudioSource MenuClose;
    public AudioSource EquipItem;

    bool speedPendantEquipped = false;

    
    private void Start()
    {
        GiveItem("Health Potion");
        GiveItem("Gold Coin");
        
        player = GameObject.FindWithTag("Player");
        inventoryUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        //go.GetComponent<UIInventory>().uIItems; 
        if (playerObj == null)
             playerObj = GameObject.Find("Player");
        if (Input.GetKeyDown(KeyCode.I)) //Open Inventory
        {
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
            if (inventoryOpen == false)
            {
                Debug.Log("Invenotry is now open");
                inventoryOpen = true;
                MenuOpen.Play();
            }
            else
            {
                Debug.Log("Inventory is now closed");
                inventoryOpen = false;
                MenuClose.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.H)) //Use a health potion
        {
            UsePot("Health Potion");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) //Equip Jump pendant
        {
            checkJumpPendant("Jump Pendant");
        }

        if (Input.GetKeyDown(KeyCode.Alpha6)) //Equip Health pendant
        {
            checkHealthPendant("Health Pendant");
        }


        if (Input.GetKeyDown(KeyCode.Alpha5)) //Equip Speed pendant
        {
            checkSpeedPendant("Speed Pendant");
        }

        if (Input.GetKeyDown(KeyCode.Q)) //Drop Item
        {
            Dropitem("Health Potion");
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

    public bool RemoveItemStr(string itemName)
    {
        bool Removed = false;
        Item itemToRemove = CheckforItemStr(itemName);
        if (itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove);
            Debug.Log("Item removed: " + itemToRemove.title);
            Removed = true;
        }
        return Removed;
    }

    //Function to Use a Potion
    public void UsePot(string itemName)
    {
        Item itemToRemove = CheckforItemStr(itemName); 
        if (itemToRemove != null) //Can be removed
        {
            characterItems.Remove(itemToRemove); //Remove potion from inventory (list object)
            Drink.Play(); //Play audio
            PlayerSingleton.Player.dealDamage(-10); //Heal ten health
            inventoryUI.RemoveItem(itemToRemove); //Remove potion from inventory (UI, when player presses I)
        }
        else
        {
            Debug.Log("No health potion in inventory");
        }
    }

    //Function to (Use/Equip) the JumpPendant
    //TODO: Ensure player cannot use this function until they picked up JumpPendant initially
    public void checkJumpPendant(string itemName)
    {
        Item itemToRemove = CheckforItemStr(itemName);
        if (itemToRemove != null) //Can be removed
        {
            characterItems.Remove(itemToRemove); //Remove pendant from inventory (list object)
            EquipItem.Play();
            PlayerSingleton.Player.jumpForce = 600.0f; //Increase JumpForce of player
            inventoryUI.RemoveItem(itemToRemove); //Remove potion from inventory (UI, when player presses I)
            Debug.Log("Item removed: " + itemToRemove.title);
        }
        else if(PlayerSingleton.Player.jumpForce == 600.0f)
        {
            GiveItem("Jump Pendant"); 
            EquipItem.Play();
            PlayerSingleton.Player.jumpForce = 440.0f;
        }
        else
        {
            Debug.Log("No pendant in inventory");
        }
    }

    public void checkHealthPendant(string itemName)
    {
        Item itemToRemove = CheckforItemStr(itemName);
        if (itemToRemove != null) //Can be removed
        {
            characterItems.Remove(itemToRemove); //Remove pendant from inventory (list object)
            EquipItem.Play();
            PlayerSingleton.Player.IncreaseMaxHealth(50); //Increase JumpForce of player
            inventoryUI.RemoveItem(itemToRemove); //Remove potion from inventory (UI, when player presses I)
            Debug.Log("Item removed: " + itemToRemove.title);
        }
        else if(PlayerSingleton.Player.health >= 101)
        {
            GiveItem("Health Pendant"); 
            EquipItem.Play();
            PlayerSingleton.Player.IncreaseMaxHealth(-50);
        }
        else
        {
            Debug.Log("No pendant in inventory");
        }
    }

    public void checkSpeedPendant(string itemName)
    {
        Item itemToRemove = CheckforItemStr(itemName);
        if (itemToRemove != null) //Can be removed
        {
            characterItems.Remove(itemToRemove); //Remove pendant from inventory (list object)
            EquipItem.Play();
            PlayerSingleton.Player.IncreaseMaxSpeed(15.0f); //Increase JumpForce of player
            inventoryUI.RemoveItem(itemToRemove); //Remove potion from inventory (UI, when player presses I)
            speedPendantEquipped = true;
            Debug.Log("Item removed: " + itemToRemove.title);
        }
        else if (speedPendantEquipped == true) //Unequip
        {
            GiveItem("Speed Pendant"); 
            EquipItem.Play();
            PlayerSingleton.Player.IncreaseMaxSpeed(-15.0f);
            speedPendantEquipped = false;
        }
        else
        {
            Debug.Log("No speed pendant in inventory");
        }

    }

    public void Dropitem(string itemName)
    {
        Item itemToRemove = CheckforItemStr(itemName);
        if (itemToRemove != null) //Can be removed
        {
            characterItems.Remove(itemToRemove); //Remove pendant from inventory (list object)
            inventoryUI.RemoveItem(itemToRemove); //Remove potion from inventory (UI, when player presses I)
            Vector3 SpawnPosition = new Vector3(playerObj.transform.position.x + 3, playerObj.transform.position.y + 3, playerObj.transform.position.z + 3);
            Instantiate(HealthPotPrefab, SpawnPosition, Quaternion.identity);
        }
    }

}
