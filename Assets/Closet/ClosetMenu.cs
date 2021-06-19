using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosetMenu : MonoBehaviour
{
    // temporal
    [HideInInspector]
    public PlayerController myPlayer;
    InventoryManager myPlayerInventory;
    List<GameObject> myObjects = new List<GameObject>();
    public List<Button> closetButtons;
    public GameObject clothBox;
    public GameObject closetMenu;
    public GameObject clothShowArea;
    public GameObject panelArea;

    [Header("My Clothes")]
    public List<Hats> myHats;
    public List<Chests> myChests;
    public List<LegWear> myLeggings;



    [Header("Positioning")]
    public int xPositionStart;
    public int yPositionStart;

    public int x_space_between_items;
    public int y_space_between_items;
    public int numColumns;
    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<PlayerController>();
        myPlayerInventory = FindObjectOfType<InventoryManager>();
    }

    // HAT BUTTON

    public void ShowHatsButton()
    {
        CheckHatsInInventory();
        clothShowArea.SetActive(true);
        UpdateHats();
        DisableMainMenuButtons();
    }

    // CHECK HATS
    void CheckHatsInInventory()
    {
        myHats.Clear();
        for (int i = 0; i < myPlayerInventory.myInventory.itemContainer.Count ; i++)
        {
            if(myPlayerInventory.myInventory.itemContainer[i].item is Hats)
            {
                myHats.Add(myPlayerInventory.myInventory.itemContainer[i].item as Hats);
            }
        }
    }

    // 
    // UPDATE HAT SELECTION
    public void UpdateHats()
    {
        if (myObjects != null)
        {
            for (int i = 0; i < myObjects.Count; i++)
            {
                Destroy(myObjects[i]);
            }
        }

        for (int i = 0; i < myHats.Count; i++)
        {
            GameObject obj = Instantiate(clothBox, Vector3.zero, Quaternion.identity, panelArea.transform);
            ClothBox myItem = obj.GetComponent<ClothBox>();
            myItem.selectedItem = myHats[i];
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            myObjects.Add(obj);
            myItem.SetImage();
         //   myItem.itemImg.sprite = myHats[i].itemImage;
        }
    }
    

    // CHEST BUTTON

    public void ShowChestsButton()
    {
        CheckChestsInInventory();
        clothShowArea.SetActive(true);
        UpdateChest();
        DisableMainMenuButtons();

    }

    void CheckChestsInInventory()
    {
        myChests.Clear();
        for (int i = 0; i < myPlayerInventory.myInventory.itemContainer.Count; i++)
        {
            if (myPlayerInventory.myInventory.itemContainer[i].item is Chests)
            {
                myChests.Add(myPlayerInventory.myInventory.itemContainer[i].item as Chests);
            }
        }
    }

    // UPDATE CHEST SELECTION
    public void UpdateChest()
    {
        if (myObjects != null)
        {
            for (int i = 0; i < myObjects.Count; i++)
            {
                Destroy(myObjects[i]);
            }
        }

        for (int i = 0; i < myChests.Count; i++)
        {
            GameObject obj = Instantiate(clothBox, Vector3.zero, Quaternion.identity, panelArea.transform);
            ClothBox myItem = obj.GetComponent<ClothBox>();
            myItem.selectedItem = myChests[i];
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            myItem.itemImg.sprite = myChests[i].itemImage;
            myObjects.Add(obj);
        }
    }

    // BOOTS BUTTON

    public void ShowBootsButton()
    {
        CheckBootsInInventory();
        clothShowArea.SetActive(true);
        UpdateBoots();
        DisableMainMenuButtons();

    }

    void CheckBootsInInventory()
    {
        myLeggings.Clear();
        for (int i = 0; i < myPlayerInventory.myInventory.itemContainer.Count; i++)
        {
            if (myPlayerInventory.myInventory.itemContainer[i].item is LegWear)
            {
                myLeggings.Add(myPlayerInventory.myInventory.itemContainer[i].item as LegWear);
            }
        }
    }

    // UPDATE CHEST SELECTION
    public void UpdateBoots()
    {
        if (myObjects != null)
        {
            for (int i = 0; i < myObjects.Count; i++)
            {
                Destroy(myObjects[i]);
            }
        }

        for (int i = 0; i < myLeggings.Count; i++)
        {
            GameObject obj = Instantiate(clothBox, Vector3.zero, Quaternion.identity, panelArea.transform);
            ClothBox myItem = obj.GetComponent<ClothBox>();
            myItem.selectedItem = myLeggings[i];
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            myItem.itemImg.sprite = myLeggings[i].itemImage;
            myObjects.Add(obj);
        }
    }

    Vector3 GetPosition(int i)
    {
        return new Vector3(xPositionStart + x_space_between_items * (i % numColumns), yPositionStart + (-y_space_between_items * (i / numColumns)), 0F);
    }

    // CLOTHES VIEW
    public void ReturnToClosetMenu()
    {
        clothShowArea.SetActive(false);
        EnableMainMenuButtons();
    }

    // CLOSET
    public void OpenCloset()
    {
        closetMenu.SetActive(true);
        myPlayer.canMove = false;
    }

    public void CloseCloset()
    {
        closetMenu.SetActive(false);
        myPlayer.canMove = true;
    }

    // BUTTONS
    public void DisableMainMenuButtons()
    {
        for (int i = 0; i < closetButtons.Count; i++)
        {
            closetButtons[i].interactable = false;
        }
    }

    public void EnableMainMenuButtons()
    {
        for (int i = 0; i < closetButtons.Count; i++)
        {
            closetButtons[i].interactable = true;
        }
    }
}
