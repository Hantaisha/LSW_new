using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public ShopView shopView;
    public ShopClerk attendee;
    public GameObject menu;
    // ENABLE/DISABLE BUTTONS DURING SHOPPING
    public List<Button> menuButtons;
    // LISTS OF HATS
    public List<Item> hatsOnSale;
    // LISTS OF CHESTS
    public List<Item> chestOnSale;
    // LISTS OF FOOT
    public List<Item> footOnSale;

    [Header("Purchase")]
    public GameObject confirmBuyPanel;
    public Item selectedItem;

    [Header("Selling")]
    public Collectible selectedItemToSell;
    public GameObject confirmSellPanel;
    public TextMeshProUGUI totalSold;
    public TextMeshProUGUI amountToSell;
    int sellCounter = 0;

    // BUY PANEL
    public void IncreaseAmountToBuy()
    {

    }

    public void DecreaseAmountToBuy()
    {

    }

    // IF YOU DON'T HAVE ENOUGH, SEND ERROR
    public void ConfirmBuy()
    {

    }

    // SELL PANEL
    
    public void IncreaseAmountToSell()
    {
        sellCounter++;
        amountToSell.text = sellCounter.ToString();
        totalSold.text = "TOTAL: " + selectedItemToSell.sellAmount * sellCounter;
    }

    public void DecreaseAmountToSell()
    {
        if (sellCounter > 1)
        {
            sellCounter--;
            amountToSell.text = sellCounter.ToString();
        }
        totalSold.text = "TOTAL: " + selectedItemToSell.sellAmount * sellCounter;
    }

    public void ConfirmSell()
    {
        // AMOUNT OF ITEM * TOTAL AMOUNT
        // ADD THAT VALUE TO THE RESOURCE MANAGER
        ResourceManage.resourceManage.MoneyUpdate(selectedItemToSell.sellAmount * sellCounter);
        // ALSO SUBSTRACT SOLD ITEM FROM INVENTORY
        attendee.playerInventory.RemoveCollectibles(selectedItemToSell, sellCounter);
        // ALSO UPDATE PANEL FROM THE TOP
        HideSellPanel();
        shopView.UpdateSellingView();
    }
    
    public void RevealSellPanel()
    {
        confirmSellPanel.SetActive(true);
        totalSold.text = "TOTAL: " + selectedItemToSell.sellAmount * sellCounter;
    }

    public void HideSellPanel()
    {
        confirmSellPanel.SetActive(false);
    }

    // SHOP PANEL
    void BeginPanelShop(List<Item> selectedItems)
    {
        shopView.itemsOnSale = selectedItems;
        shopView.shopPanel.SetActive(true);
        shopView.UpdateDisplay();
    }

    void BeginSellingBuyout(List<CollectibleSlot> selling)
    {
        shopView.collectiblesPlayer = selling;
        shopView.shopPanel.SetActive(true);
        shopView.UpdateSellingView();
    }
  
    public void ActionShopMenu(int index)
    {
        switch (index)
        {
            // HAT
            case 1:
                BeginPanelShop(hatsOnSale);
                DisableMainMenuButtons();
                break;

            // CHEST
            case 2:
                BeginPanelShop(chestOnSale);
                DisableMainMenuButtons();
                break;

            // BOOTS
            case 3:
                BeginPanelShop(footOnSale);
                DisableMainMenuButtons();
                break;
        
            // SELL MENU
            case 4:
                BeginSellingBuyout(attendee.playerInventory.myInventory.sellableItems);
                DisableMainMenuButtons();
                break;

            case 5:
                Debug.Log("Talk");
                // PASS LINE DIALOG OF SHOPKEEPER
                break;

            case 6:
                CloseMenu();
                break;
              
        }
    }


    // MAIN MENU SHOP CONTROL
    public void CloseMenu()
    {
        menu.SetActive(false);
        attendee.CloseShop();
    }

    public void OpenMenu(ShopClerk user)
    {
        attendee = user;
        menu.SetActive(true);
    }

    public void DisableMainMenuButtons()
    {
        for (int i = 0; i < menuButtons.Count; i++)
        {
            menuButtons[i].interactable = false;
        }
    }

    public void EnableMainMenuButtons()
    {
        for (int i = 0; i < menuButtons.Count; i++)
        {
            menuButtons[i].interactable = true;
        }
    }
}
