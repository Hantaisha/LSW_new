using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    // WHAT ITEM
    public Collectible typeCollectible;
    public int amountCollection;
    // DETECTION
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // must add to inventory
            Inventory playerInventory = collision.GetComponent<InventoryManager>().myInventory;
            playerInventory.AddCollectible(typeCollectible, amountCollection);
        }
        Debug.Log("OKAY!");
        
        // destroy object
        Destroy(this.gameObject);
    }
}
