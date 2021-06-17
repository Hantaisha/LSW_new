using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManage : MonoBehaviour
{
    public static ResourceManage resourceManage;

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
        
    }

    public void MoneyUpdate(int value)
    {
        money += value;
    }


}
