using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopClerk : MonoBehaviour
{
    ShopManager shopBrain;
    PlayerMovement playerTarget;
    [HideInInspector]
    public InventoryManager playerInventory;
    bool playerIn;
    DialogBox targetDialog;

    [Header("Dialog")]
    public List<string> greeting;
    int timeGreeting = 0;

    public List<string> talking;
    int actionCount = 1;

    // Start is called before the first frame update

    // GET SHOP MANAGER
    void Start()
    {
        shopBrain = GameObject.FindObjectOfType<ShopManager>();

        if (targetDialog == null)
        {
            targetDialog = GameObject.Find("Dialog").GetComponent<DialogBox>();
        }
    }

    public void OpenShop()
    {
        shopBrain.OpenMenu(this);
    }

    public void CloseShop()
    {
        playerTarget.canMove = true;
    }

    // DETECTOR
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = true;
            playerTarget = other.GetComponent<PlayerMovement>();
            playerInventory = other.GetComponent<InventoryManager>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = false;
            playerTarget = null;
            playerInventory = null;
        }
    }

    // INTERACTION

        // INTERACT NPC -> DIALOG -> SHOP MENU

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIn)
        {

            switch (actionCount) {

                case 1:
                    // DIALOG
                    targetDialog.ActivateDialog();
                    targetDialog.SetDialogText(greeting[timeGreeting]);
                    playerTarget.canMove = false;
                    if (timeGreeting > 0)
                    {
                        timeGreeting = 0;
                    }
                    else
                    {
                        timeGreeting++;
                    }
                    actionCount++;
                    break;

                case 2:
                    // OPEN MENU
                    if (!shopBrain.menu.activeInHierarchy)
                    {
                        targetDialog.HideDialog();
                        actionCount = 1;
                        OpenShop();
                    }
                    else
                    {
                        Debug.Log("ERROR");
                    }
                    break;
            
        }
    }
                
           
        
    }
}
