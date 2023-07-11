using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked = true;
    public Collider2D doorCollider;

    private InventoryController inventory;

    private void Start()
    {
        inventory = FindObjectOfType<InventoryController>();
    }

    private void Update()
    {
        if (isLocked && Input.GetKeyDown(KeyCode.E) && inventory != null && inventory.GetKeyCount() > 0)
        {
            inventory.UseKey();
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        isLocked = false;

        if (doorCollider != null)
        {
            doorCollider.enabled = false;
        }

        // Realizar otras acciones necesarias para abrir la puerta, como reproducir animaciones, etc.
    }

    private void OnValidate()
    {
        if (!isLocked && doorCollider != null)
        {
            doorCollider.enabled = false;
        }
    }
}
