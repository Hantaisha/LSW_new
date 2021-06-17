using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectible", menuName = "ScriptableObjects/New Collectible", order = 1)]
public class Collectible : ScriptableObject
{
    public string itemName;
    [TextArea(15, 20)]
    public string description;
    public Sprite itemImage;
    public int sellAmount;
}
