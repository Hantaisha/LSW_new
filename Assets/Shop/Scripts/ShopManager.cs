using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ShopView shopView;
    public GameObject menu;
    // ENABLE/DISABLE BUTTONS DURING SHOPPING
    public List<Button> menuButtons;
    // LISTS OF HATS
    public List<Item> hatsOnSale;
    // LISTS OF CHESTS
    public List<Item> chestOnSale;
    // LISTS OF FOOT
    public List<Item> footOnSale;

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

    void BeginPanelShop(List<Item> selectedItems)
    {
        shopView.itemsOnSale = selectedItems;
        shopView.shopPanel.SetActive(true);
        shopView.UpdateDisplay();
    }

    public void ActionShopMenu(int index)
    {
        switch (index)
        {
            case 1:
                BeginPanelShop(hatsOnSale);
                DisableMainMenuButtons();
                break;

            case 2:
                BeginPanelShop(chestOnSale);
                DisableMainMenuButtons();
                break;

            case 3:
                BeginPanelShop(footOnSale);
                DisableMainMenuButtons();
                break;

            case 4:
                Debug.Log("Sell");
                break;

            case 5:
                Debug.Log("Talk");
                break;

            case 6:
                CloseMenu();
                break;
              
        }
    }

    void CloseMenu()
    {
        menu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
