using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();


    //Function called when the game has started to intialize the database
    private void Awake()
    {
        BuildDatabase();
    }

    //Returns item using its id
    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    //Returns item using its name
    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }
    //Creates the Database that will hold the information of all items in the game
    //Item (id, title, description)
    //Dictionary of item (stat, value)
    public void BuildDatabase()
    {
        items = new List<Item>
        {
            new Item(0, "Normal Sword", "A sword used by the common folk.",
            new Dictionary<string, int>
            {
                {"Power", 15 },
                {"Defence", 10}
            }),
            new Item(1, "Health Potion", "A potion to restore HP slightly.",
            new Dictionary<string, int>
            {
                {"HP Restored", 10 }
            }),
            new Item(2, "Mana Potion", "A potion to restore mana slightly.",
            new Dictionary<string, int>
            {
                {"Mana Restored", 10 }
            }),
            new Item(3, "Gold Coin", "No personal value, perhaps can be sold for a high price.",
            new Dictionary<string, int>
            {
                {"Sell Value", 50 }
            }),
            new Item(4, "Health Pendant", "An accessory that will slightly increase your max hp.",
            new Dictionary<string, int>
            {
                {"HP increase", 10 }
            }),
            new Item(5, "Regular Key", "A regular key, may be used to open a locked door.",
            new Dictionary<string, int>
            {
                {"Sell Value", 5 }
            }),
        };
    }
    
}
