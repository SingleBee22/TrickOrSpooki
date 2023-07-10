using UnityEngine;

public class Char_Movement : MonoBehaviour
{
    public float detachThreshold = 10f;
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje

    private int pressCountA;
    private int pressCountD;
    private bool isPlayerLocked = false;
    EnemyController enemyLock = null;
    private Rigidbody2D rb; // Componente Rigidbody2D para el movimiento físico

    private void Start()
    {

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

    public void LockPlayer(EnemyController other)
    {
        enemyLock = other;
        isPlayerLocked = true;
    }

    public bool IsLockPlayer(EnemyController other)
    {
        return isPlayerLocked && enemyLock.GetHashCode() == other.GetHashCode();
    }

    public void UnlockPlayer()
    {
        enemyLock.gameObject.SetActive(false);
        enemyLock = null;
        isPlayerLocked = false;
        pressCountA = 0;
        pressCountD = 0;
    }

    private void CheckDetach()
    {
        if (pressCountA >= detachThreshold && pressCountD >= detachThreshold)
        {
            UnlockPlayer();
        }
    }

    private void Move(float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }
}
