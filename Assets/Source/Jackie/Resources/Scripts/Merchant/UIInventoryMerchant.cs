using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryMerchant : MonoBehaviour
{
    public List<UIItemMerchant> uIItemsMerchant = new List<UIItemMerchant>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int numberOfSlots = 3; //Needed 
    // Start is called before the first frame update

    private void Awake()
    {
        for(int i = 0; i < numberOfSlots; i++)
        
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uIItemsMerchant.Add(instance.GetComponentInChildren<UIItemMerchant>());
        }
    } 


    //Show or Remove specific item in slot
    public void UpdateSlot(int slot, ItemMerchant item)
    {
        uIItemsMerchant[slot].UpdateItem(item);
    }

    public void AddNewItem(ItemMerchant item)
    {
        UpdateSlot(uIItemsMerchant.FindIndex(j => j.item == null), item);
    }

    public void RemoveItem(ItemMerchant item)
    {
       UpdateSlot(uIItemsMerchant.FindIndex(i => i.item == item), null);
    }
}
