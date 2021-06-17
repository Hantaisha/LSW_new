using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour
{
    public string dialog;
    public bool playerIn;
    DialogBox targetDialog;
    PlayerMovement playerTarget;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = true;
            playerTarget = other.GetComponent<PlayerMovement>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = false;
            playerTarget = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(targetDialog == null)
        {
            targetDialog = GameObject.Find("Dialog").GetComponent<DialogBox>();
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.E) && playerIn)
        {
            if (targetDialog.IsDialogActive())
            {
                targetDialog.HideDialog();
                playerTarget.canMove = true;
                //
            }
            else
            {
                targetDialog.ActivateDialog();
                targetDialog.SetDialogText(dialog);
                playerTarget.canMove = false;
                //
            }
        }
    }
}
