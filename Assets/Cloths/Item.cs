using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cloth", menuName = "ScriptableObjects/New Cloth", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    [TextArea(15, 20)]
    public string description;
  //  public GameObject prefab;
    public Sprite itemImage;
    public ItemType itemType;
    public int costAmount;
}

public enum ItemType
{
    Hat,
    Chest,
    Foot
}

