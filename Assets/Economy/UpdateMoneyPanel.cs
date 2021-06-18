using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateMoneyPanel : MonoBehaviour
{
    TextMeshProUGUI myText;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = ResourceManage.resourceManage.money.ToString();
    }
}
