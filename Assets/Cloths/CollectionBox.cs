using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectionBox : MonoBehaviour
{
    public Collectible selectedCollectible;
    public TextMeshProUGUI textbox;
    public TextMeshProUGUI amountText;
    public Image itemImg;
    public int currentValue;
    ShopManager shopManager;

    public void SetCollectibleText()
    {
        currentValue = selectedCollectible.sellAmount;
        textbox.text = currentValue.ToString();
        itemImg.sprite = selectedCollectible.itemImage;
    }

    public void SetAmount(int amount)
    {
        amountText.text = amount.ToString();
    }

    private void Awake()
    {
        if(shopManager == null)
        {
            shopManager = FindObjectOfType<ShopManager>();
        }
        // FIND THE MANAGER WHEN CREATED
    }

    public void OpenCollectableConfirm()
    {
        shopManager.selectedItemToSell = selectedCollectible;
        shopManager.RevealSellPanel();
        //  ShopManager.shop.itemImg.sprite = selectedItem.itemImage;
        //   ShopManager.shop.itemDescription.text = selectedItem.description;
        //    ShopManager.shop.priceTotal.text = "TOTAL = " + currentPrice;
    }
}
