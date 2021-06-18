using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGet : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ResourceManage.resourceManage.MoneyUpdate(value);
            Destroy(this.gameObject);
        }
    }
}
