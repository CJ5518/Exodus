using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uIItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    private Vector2 vPos; //Stress Test Parameter
    public int numberOfSlots = 84; //Needed 

    //Create slots in the panel and save it to the uIItems list to be modified
    /*
    private void Awake()
    {
        for(int i = 0; i < numberOfSlots; i++)
        
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uIItems.Add(instance.GetComponentInChildren<UIItem>());
        }
    }    
    */ 
    //Stress Test Version
    private void Awake() 
    {

        for(int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uIItems.Add(instance.GetComponentInChildren<UIItem>());
            Debug.Log("numberOfSlots " + i );
        }
        
    }

    //Show or Remove specific item in slot
    public void UpdateSlot(int slot, Item item)
    {
        uIItems[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        UpdateSlot(uIItems.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(uIItems.FindIndex(i => i.item== item), null);
    }
}
