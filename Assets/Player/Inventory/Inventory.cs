using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventorySlot> itemContainer = new List<InventorySlot>();

    // ADD
    public void AddItem(Item itemObject, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < itemContainer.Count; i++)
        {
            if (itemContainer[i].item == itemObject)
            {
                itemContainer[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }

        if (!hasItem)
        {
            itemContainer.Add(new InventorySlot(itemObject, _amount));
        }
    }
        
    public List<CollectibleSlot> sellableItems = new List<CollectibleSlot>();
    CollectibleSlot bufferCollectibleSlot;

    public void AddCollectible(Collectible item, int amount)
    {
        bool hasItem = false;

        // CHECK ALL INVENTORY
        for (int i = 0; i < sellableItems.Count; i++)
        {
            // IF THERE'S A COPY, ADD ONLY AMOUNT
            if (sellableItems[i].collectable == item)
            {
                sellableItems[i].AddAmount(amount);
                hasItem = true;
                break;
            }
        }
        
        // IF NO ITEM FOUND, CREATE AND ADD TO INVENTORY A SLOT
        if (!hasItem)
        {
            sellableItems.Add(new CollectibleSlot(item, amount));
        }
    }
    
    public void RemoveCollectable(Collectible item, int _amount)
    {
        // CHECK ALL INVENTORY
        for (int i = 0; i < sellableItems.Count; i++)
        {
            // IF THERE'S A COPY, ADD ONLY AMOUNT
            if (sellableItems[i].collectable == item)
            {
                // CHECK IF YOU ARE NOT REMOVING MORE THAN YOU HAVE
                if(sellableItems[i].amount < _amount)
                {
                    Debug.Log("Error");
                }
                else
                {
                    sellableItems[i].RemoveAmount(_amount);
                    // REMEMBER SLOT TARGET
                    bufferCollectibleSlot = sellableItems[i];
                }
                break;
            }
        }

        if(bufferCollectibleSlot != null && bufferCollectibleSlot.amount == 0)
        {
            sellableItems.Remove(bufferCollectibleSlot);
            bufferCollectibleSlot = null;
        }

    }
    
}

[System.Serializable]
public class InventorySlot
{
    public Item item;
    public int amount;

    public InventorySlot(Item _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public void SubstractAmount(int value)
    {
        amount -= value;
    }

}

[System.Serializable]
public class CollectibleSlot
{
    public Collectible collectable;
    public int amount;

    public CollectibleSlot(Collectible _item, int _amount)
    {
        collectable = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public void RemoveAmount(int value)
    {
        amount -= value;
    }

}
