using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
//using cj;


public class BoundaryTest
{
    Inventory inventory = new GameObject().AddComponent<Inventory>();
    ItemDatabase itemDatabase = new GameObject().AddComponent<ItemDatabase>();
    UIInventory uiInventory = new GameObject().AddComponent<UIInventory>();
    public AudioSource Drink;
    public List<Item> characterItems = new List<Item>();
    
    [Test]
    //Current Inventory system avoids removing items that it does not have
    public void PreventNegativeInventoryTest()
    {
        List<Item> characterItemsBefore = new List<Item>(); //For comparison
        characterItemsBefore = characterItems; //Set them equal 
        itemDatabase.BuildDatabase(); //Must be built before item can be added
        inventory.RemoveItemStr("Health Potion"); //Attempt to remove an item from an empty inventory
        Assert.AreEqual(characterItemsBefore , characterItems); //Empty inventory, should expect to remain empty compare the two
    }

    [Test]
    //Current Inventory Checks for Cap
    public void CheckOverFlow()
    {
        itemDatabase.BuildDatabase(); //Must be built before item can be added
        int i = 0;
        while(i <= 16)
        {
            Item itemToAdd = itemDatabase.GetItem("Health Potion"); //Get item info from database
            characterItems.Add(itemToAdd); //Add to characters inventory
            i++;
        }
        Item FinalitemToAdd = itemDatabase.GetItem("Regular Key"); //Get item info from database
        characterItems.Add(FinalitemToAdd); //Add to characters inventory
        //Assert.AreEqual(characterItems[16], itemDatabase.GetItem("Health Potion"));
        Assert.AreNotEqual(itemDatabase.GetItem("Regular Key") , uiInventory.uIItems[15]);
    }
    
    [Test]
    public void JumpForce()
    {
        itemDatabase.BuildDatabase(); //Must be built before item can be added
        Item itemToAdd = itemDatabase.GetItem("Jump Pendant"); //Get item info from database
        characterItems.Add(itemToAdd); //Add to characters inventory
        
        Item itemToRemove = characterItems[0]; //Check first item in inventory (Only Item)
        if (itemToRemove != null) //Can be removed
        {
            characterItems.Remove(itemToRemove); //Remove pendant from inventory (list object)
            PlayerSingleton.Player.jumpForce = 600.0f; //Increase JumpForce of player
        }
        Assert.AreEqual(PlayerSingleton.Player.jumpForce, 600.0);
    }

    [Test]
    public void Heal()
    {
        PlayerSingleton.Player.dealDamage(10);
        int occured_flag = 0;
        itemDatabase.BuildDatabase(); //Must be built before item can be added
        Item itemToAdd = itemDatabase.GetItem("Health Potion"); //Get item info from database
        characterItems.Add(itemToAdd); //Add to characters inventory
        
        Item itemToRemove = characterItems[0]; //Check first item in inventory (Only Item)
        if (itemToRemove != null) //Can be removed
        {
            characterItems.Remove(itemToRemove); //Remove pendant from inventory (list object)
            PlayerSingleton.Player.dealDamage(-10);
            occured_flag = 1;
        }
        Assert.AreEqual(occured_flag, 1);
    }

}
