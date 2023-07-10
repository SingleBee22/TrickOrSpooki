using UnityEngine;

public class Char_Movement : MonoBehaviour
{
    public int maxHealth = 10;
    public float detachThreshold = 10f;
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje

    private float currentHealth;
    private int pressCountA;
    private int pressCountD;
    private bool isPlayerLocked = false;
    private Rigidbody2D rb; // Componente Rigidbody2D para el movimiento físico

    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D
    }

    private void Update()
    {
        if (!isPlayerLocked)
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            if (horizontalInput != 0f)
            {
                Move(horizontalInput);
            }
        }

        if (isPlayerLocked)
        {
            // Detecta las pulsaciones de teclas
            if (Input.GetKeyDown(KeyCode.A))
            {
                pressCountA++;
                CheckDetach();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                pressCountD++;
                CheckDetach();
            }
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (!isPlayerLocked)
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                // Realiza acciones cuando el jugador se quede sin salud
                // ...
            }
        }
    }

    public void LockPlayer()
    {
        isPlayerLocked = true;
    }

    public void UnlockPlayer()
    {
        isPlayerLocked = false;
        pressCountA = 0;
        pressCountD = 0;
    }

    private void CheckDetach()
    {
        if (pressCountA >= detachThreshold && pressCountD >= detachThreshold)
        {
            isPlayerLocked = false;
            pressCountA = 0;
            pressCountD = 0;
        }
    }

    private void Move(float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }
}
