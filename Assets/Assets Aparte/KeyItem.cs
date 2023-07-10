using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public InventoryController ic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InventoryController inventory = ic;
            if (inventory != null)
            {
                inventory.AddKey();
                Destroy(gameObject);
            }
        }
    }
}