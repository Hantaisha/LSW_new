using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventorySlot> itemContainer = new List<InventorySlot>();

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

}
