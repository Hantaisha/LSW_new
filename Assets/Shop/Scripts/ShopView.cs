using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopView : MonoBehaviour
{
    public ShopManager manager;

    public List<Item> itemsOnSale;
    public GameObject shopPanel;
    public GameObject itemBox;
    public GameObject panelArea;

    public int xPositionStart;
    public int yPositionStart;

    public int x_space_between_items;
    public int y_space_between_items;
    public int numColumns;

    // AQUI NO
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
