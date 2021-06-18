using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManage : MonoBehaviour
{
    public static ResourceManage resourceManage;

    Translate2point moneyUI;
    public int money = 0;


    void Awake()
    {
        if (resourceManage == null)
        {
            DontDestroyOnLoad(gameObject);
            resourceManage = this;
        }
        else if (resourceManage != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moneyUI == null)
        {
            moneyUI = GameObject.Find("MoneyPanel").GetComponent<Translate2point>();
        }
    }

    public void MoneyUpdate(int value)
    {
        moneyUI.RevealPopUp();
        money += value;
        // MOVE THE SIGN
    }


}
