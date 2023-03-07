using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BoundaryTest
{
    Inventory inventory = new GameObject().AddComponent<Inventory>();
    ItemDatabase itemDatabase = new GameObject().AddComponent<ItemDatabase>();

    public List<Item> characterItems = new List<Item>();
    [Test]
    //Current Inventory system avoids removing items that it does not have
    public void TestifItemListGoesNegative()
    {
        List<Item> characterItemsBefore = new List<Item>(); //For comparison
        characterItemsBefore = characterItems; //Set them equal 
        itemDatabase.BuildDatabase(); //Must be built before item can be added
        inventory.RemoveItemStr("Health Potion"); //Attempt to remove an item from an empty inventory
        Assert.AreEqual(characterItemsBefore , characterItems); //Empty inventory, should expect to remain empty compare the two
    }

    [Test]
    //Current Inventory does not check for max cap, hence resulting in successfully overfilling the inventory
    public void CanOverFlow()
    {
        itemDatabase.BuildDatabase(); //Must be built before item can be added
        int i = 0;
        while(i <= 17)
        {
            Item itemToAdd = itemDatabase.GetItem("Health Potion"); //Get item info from database
            characterItems.Add(itemToAdd); //Add to characters inventory
            i++;
        }
        //Assert.AreEqual(characterItems[16], itemDatabase.GetItem("Health Potion"));
        Assert.AreEqual(itemDatabase.GetItem("Health Potion") ,characterItems[16]);
    }

}
