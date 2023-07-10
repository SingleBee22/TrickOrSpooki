using UnityEngine;

public class CandyItem : MonoBehaviour
{
    public int scoreValue = 10;

    public InventoryController ic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InventoryController inventory = ic;
            if (inventory != null)
            {
                inventory.AddScore(scoreValue);
                Destroy(gameObject);
            }
        }
    }
}