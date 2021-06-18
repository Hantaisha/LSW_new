using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public Inventory myInventory;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    
    // ITEMS
    public void AddToInventory(Item newItem, int amount)
    {
        myInventory.AddItem(newItem, amount);
    }

    public void FindItem(InventorySlot targetItem)
    {
        InventorySlot item = myInventory.itemContainer.Find(x => x.item == targetItem.item);
    }

    // COLLECTABLE SELLABLE
    public void RemoveCollectibles(Collectible item, int amount)
    {
        myInventory.RemoveCollectable(item, amount);
    }
}
