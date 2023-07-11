using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public UnityEvent inPlayerDeath;

    public Image fullHealthImage;
    public Image halfHealthImage;
    public Image lowHealthImage;

    public int maxHealth = 8;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthVisuals();
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthVisuals();

        if (currentHealth <= 0)
        {
            // Acciones cuando el jugador se quede sin salud (pierde)
            // ...
            PlayerLost();
        }
    }

    private void UpdateHealthVisuals()
    {
        if (currentHealth >= maxHealth)
        {
            fullHealthImage.gameObject.SetActive(true);
            halfHealthImage.gameObject.SetActive(false);
            lowHealthImage.gameObject.SetActive(false);
        }
        else if (currentHealth >= maxHealth / 2)
        {
            fullHealthImage.gameObject.SetActive(false);
            halfHealthImage.gameObject.SetActive(true);
            lowHealthImage.gameObject.SetActive(false);
        }
        else
        {
            fullHealthImage.gameObject.SetActive(false);
            halfHealthImage.gameObject.SetActive(false);
            lowHealthImage.gameObject.SetActive(true);
        }
    }

    private void PlayerLost()
    {
        inPlayerDeath.Invoke();
        // Acciones específicas cuando el jugador pierde (por ejemplo, reiniciar el nivel, mostrar una pantalla de game over, etc.)
        // ...
        SceneManager.LoadScene("GameOver");
    }
}