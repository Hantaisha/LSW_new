using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetTrigger : MonoBehaviour
{
    public bool playerIn;
    public ClosetMenu closetMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIn = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = false;
        }
    }

    private void Update()
    {
        if(playerIn && Input.GetKeyDown(KeyCode.E))
        {
            closetMenu.OpenCloset();
        }
    }
}
