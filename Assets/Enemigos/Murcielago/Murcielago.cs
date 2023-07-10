using UnityEngine;

public class Murcielago : MonoBehaviour
{
    public Sprite idleSprite;
    public Sprite attackSprite;
    public float movementSpeed = 5f;
    public int damageAmount = 2;

    private SpriteRenderer spriteRenderer;
    private Transform playerTransform;
    private bool isActivated = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = FindObjectOfType<Char_Movement>().transform;

        SetSprite(idleSprite);
    }

    public void Activate()
    {
        if (!isActivated)
        {
            isActivated = true;
            SetSprite(attackSprite);
            MoveTowardsPlayer();
        }
    }

    private void Update()
    {
        if (isActivated)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    private void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActivated && collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            Destroy(gameObject);
        }
    }
}