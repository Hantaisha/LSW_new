using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogBox : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI textbox;

    void Start()
    {
        dialogBox.SetActive(false);
    }

    public bool IsDialogActive()
    {
        return dialogBox.activeInHierarchy;
    }

    public void HideDialog()
    {
        dialogBox.SetActive(false);
    }

    public void ActivateDialog()
    {
        dialogBox.SetActive(true);
    }

    public void SetDialogText(string dText)
    {
        textbox.text = dText;
    }
    
}
