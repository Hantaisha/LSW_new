using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopView : MonoBehaviour
{
    public ShopManager manager;

    [Header("Selling Clothes")]
    public List<Item> itemsOnSale;

    [Header("Buying vendor Trash")]
    public List<CollectibleSlot> collectiblesPlayer;
    List<GameObject> foundCollectibles = new List<GameObject>();

    [Header("Positioning")]
    public GameObject shopPanel;
    public GameObject itemBox;
    public GameObject collectableBox;
    public GameObject panelArea;

    public int xPositionStart;
    public int yPositionStart;

    public int x_space_between_items;
    public int y_space_between_items;
    public int numColumns;

    // UPDATE CLOTHES ON SALE
    public void UpdateDisplay()
    {
        for (int i = 0; i < itemsOnSale.Count; i++)
        {
            var obj = Instantiate(itemBox, Vector3.zero, Quaternion.identity, panelArea.transform);
            ItemBox myItem = obj.GetComponent<ItemBox>();
            myItem.selectedItem = itemsOnSale[i];
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            myItem.priceTag.text = myItem.currentPrice.ToString();
            myItem.SetPriceText();
        }
    }

    // UPDATE SELLING ITEMS ON OFFER
    public void UpdateSellingView()
    {
        // DELETE EXISTING SLOTS
        DestroyPreviousSellingSlots();

        for (int i = 0; i < collectiblesPlayer.Count; i++)
        {
            GameObject obj = Instantiate(collectableBox, Vector3.zero, Quaternion.identity, panelArea.transform);
            CollectionBox myItem = obj.GetComponent<CollectionBox>();
            myItem.selectedCollectible = collectiblesPlayer[i].collectable;
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            myItem.textbox.text = myItem.currentValue.ToString();
            myItem.SetAmount(collectiblesPlayer[i].amount);
            foundCollectibles.Add(obj);
            myItem.SetCollectibleText();
        }
    }

    void DestroyPreviousSellingSlots()
    {
        if(foundCollectibles != null)
        {
            for (int i = 0; i < foundCollectibles.Count; i++)
            {
                Destroy(foundCollectibles[i]);
            }
        }
        
    }
    
    Vector3 GetPosition(int i)
    {
        return new Vector3(xPositionStart + x_space_between_items * (i % numColumns), yPositionStart + (-y_space_between_items * (i / numColumns)), 0F);
    }

    public void ReturnToMainMenu()
    {
        manager.EnableMainMenuButtons();
        shopPanel.SetActive(false);
    }
}
