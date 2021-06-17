using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public Inventory myInventory;
    
    public Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }
    

    public void AddToInventory(Item newItem, int amount)
    {
        myInventory.AddItem(newItem, amount);
    }

    
}
