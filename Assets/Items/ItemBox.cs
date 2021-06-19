using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemBox : MonoBehaviour
{
    public Item selectedItem;
    public TextMeshProUGUI priceTag;
    public Image itemImg;
    ShopManager shopManager;

    public int currentPrice;

    private void Awake()
    {
        if (shopManager == null)
        {
            shopManager = FindObjectOfType<ShopManager>();
        }
        // FIND THE MANAGER WHEN CREATED
    }

    public void SetPriceText()
    {
        currentPrice = selectedItem.costAmount;
        priceTag.text = currentPrice.ToString();
        itemImg.sprite = selectedItem.itemImage;
    }

    // ON CLICK
    public void OpenItemConfirm()
    {
        shopManager.selectedItem = selectedItem;
        shopManager.descriptionText.text = shopManager.selectedItem.description;
        shopManager.RevealBuyPanel();
    }
    
}