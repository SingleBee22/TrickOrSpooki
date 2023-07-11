using UnityEngine;

public class Dc : MonoBehaviour
{
    public Door door;
    public SpriteRenderer unlockedSpriteRenderer;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (door == null)
        {
            Debug.LogError("No se ha asignado el script Door en el inspector.");
        }
    }

    private void Update()
    {
        if (door != null && !door.isLocked)
        {
            ChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        if (spriteRenderer != null && unlockedSpriteRenderer != null)
        {
            spriteRenderer.sprite = unlockedSpriteRenderer.sprite;
        }
    }
}
