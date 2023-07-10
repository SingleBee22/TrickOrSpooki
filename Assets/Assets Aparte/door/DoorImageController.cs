using UnityEngine;

public class DoorImageController : MonoBehaviour
{
    public Sprite doorOpenSprite;
    public Sprite doorClosedSprite;

    private SpriteRenderer spriteRenderer;
    private Door door;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        door = GetComponent<Door>();
        CloseDoorImage();
        // UpdateDoorImage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UpdateDoorImage();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CloseDoorImage();
        }
    }

    private void UpdateDoorImage()
    {
        if (door.isLocked)
        {
            spriteRenderer.sprite = doorClosedSprite;
        }
        else
        {
            spriteRenderer.sprite = doorOpenSprite;
        }
    }

    private void CloseDoorImage()
    {
        spriteRenderer.sprite = doorClosedSprite;

    }
}