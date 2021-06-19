using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothBox : MonoBehaviour
{
    public Item selectedItem;
    public Image itemImg;
    ClosetMenu menu;
    // Start is called before the first frame update

    private void Awake()
    {
        if (menu == null)
        {
            menu = FindObjectOfType<ClosetMenu>();
        }
        // FIND THE MANAGER WHEN CREATED
    }


    public void SetImage()
    {
        itemImg.sprite = selectedItem.itemImage;
    }

    public void OnPressItem()
    {
        if(selectedItem is Hats)
        {
            Debug.Log("I am a hat");
            menu.myPlayer.SetEquipHead((Hats)selectedItem);

        }

        if(selectedItem is Chests)
        {
            Debug.Log("I am a chest");
            menu.myPlayer.SetEquipChest((Chests)selectedItem);
        }

        if (selectedItem is LegWear)
        {
            Debug.Log("I am a leg");
            menu.myPlayer.SetEquipBoots((LegWear)selectedItem);
        }
    }
}
