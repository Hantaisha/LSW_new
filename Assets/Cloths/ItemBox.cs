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

    public void OpenItemConfirm()
    {
        shopManager.selectedItem = selectedItem;

     //   ShopManager.shop.itemBoxSelected = this;
     //   ShopManager.shop.purchaseConfirmBox.SetActive(true);
      //  ShopManager.shop.itemImg.sprite = selectedItem.itemImage;
     //   ShopManager.shop.itemDescription.text = selectedItem.description;
    //    ShopManager.shop.priceTotal.text = "TOTAL = " + currentPrice;
    }

    // PRICE MODIFICATIONS
    /*
    public void Discount(float percentage)
    {
        float discount = currentPrice * (percentage / 100);
        int discountInt = (int)discount;
        // 20%
        // 20%(50) = PRICE * (MOD/100)
        currentPrice -= discountInt;
        priceTag.text = currentPrice.ToString();
        // RESTORE BOXES TO NORMAL
    }

    public void Charge(float percentage)
    {
        float discount = currentPrice * (percentage / 100);
        int discountInt = (int)discount;
        // 20%
        // 20%(50) = PRICE * (MOD/100)
        currentPrice += discountInt;
        priceTag.text = currentPrice.ToString();
    }

    public void RestorePrice()
    {
        currentPrice = defaultPrice;
        priceTag.text = currentPrice.ToString();
    }*/
}