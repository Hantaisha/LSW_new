using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string itemName;
    [TextArea(15, 20)]
    public string description;
    public Sprite itemImage;
    public int costAmount;
    public RuntimeAnimatorController animatorController;
}


