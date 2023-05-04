using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabaseMerchant : MonoBehaviour
{

    public List<ItemMerchant> items = new List<ItemMerchant>();
    
    private void Awake()
    {
        BuildDatabase();
    }
    //Returns item using its id
    public ItemMerchant GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    //Returns item using its name
    public ItemMerchant GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }
    
    //Creates the Database that will hold the information of all items in the game
    //Item (id, title, description)
    //Dictionary of item (stat, value)
    public void BuildDatabase()
    {
        items = new List<ItemMerchant>
        {
            new ItemMerchant(0, "Normal Sword", "A sword used by the common folk.",
            new Dictionary<string, int>
            {
                {"Power", 15 },
                {"Defence", 10}
            }),
            new ItemMerchant(1, "Health Potion", "A potion to restore HP slightly. [G] to purchase",
            new Dictionary<string, int>
            {
                {"HP Restored", 10 }
            }),
            new ItemMerchant(2, "Mana Potion", "A potion to restore mana slightly.",
            new Dictionary<string, int>
            {
                {"Mana Restored", 10 }
            }),
            new ItemMerchant(3, "Gold Coin", "No personal value, perhaps can be sold for a high price.",
            new Dictionary<string, int>
            {
                {"Sell Value", 50 }
            }),
            new ItemMerchant(4, "Health Pendant", "An accessory that will slightly increase your max hp [B] to purchase.",
            new Dictionary<string, int>
            {
                {"HP increase", 50 }
            }),
            new ItemMerchant(5, "Regular Key", "A regular key, may be used to enter the boss room. [B] to purchase",
            new Dictionary<string, int>
            {
                {"Sell Value", 5 }
            }),
            new ItemMerchant(6, "Speed Pendant", "An accessory that will slightly increase your movement speed. [V] to purchase",
            new Dictionary<string, int>
            {
                {"Speed Increase", 5 }
            }),
            new ItemMerchant(7, "Jump Pendant", "An accessory that will slightly increase your Jump ability. [F] to purchase",
            new Dictionary<string, int>
            {
                {"Jump Increase", 160 }
            })
        };
    }
    
}
