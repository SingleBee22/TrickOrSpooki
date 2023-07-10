using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked = true;

    private void Update()
    {
        if (isLocked && Input.GetKeyDown(KeyCode.E))
        {
            InventoryController inventory = FindObjectOfType<InventoryController>();
            if (inventory != null && inventory.GetKeyCount() > 0)
            {
                inventory.UseKey();
                OpenDoor();
            }
        }
    }

    private void OpenDoor()
    {
        isLocked = false;
        // Realiza las acciones necesarias para abrir la puerta, como desactivar la visualización, reproducir animaciones, etc.
    }
}
