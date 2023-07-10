using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryItem : MonoBehaviour
{
    public InventoryController ic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InventoryController inventory = ic;
            if (inventory != null)
            {
                inventory.AddBattery();
                Destroy(gameObject);
            }
        }
    }
}