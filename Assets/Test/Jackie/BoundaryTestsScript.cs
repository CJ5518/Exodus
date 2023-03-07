using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BoundaryTestsScript
{
    Inventory inventory = new GameObject().AddComponent<Inventory>();
    ItemDatabase itembase = new GameObject().AddComponent<ItemDatabase>();
    //public ItemDatabase itemDatabase;
    public List<Item> characterItems = new List<Item>();
    public UIInventory inventoryUI;

    // A Test behaves as an ordinary method
    [Test]
    public void CheckItem()
    {
        itembase.BuildDatabase();
        //itemDatabase.BuildDatabase();
        Item itemToAdd = itembase.GetItem("Health Potion");
        characterItems.Add(itemToAdd);

        Assert.AreEqual(characterItems[0], itembase.GetItem("Health Potion"));
    }


}
