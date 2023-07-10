using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject inventoryUI;

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;

        // Mostrar el inventario
        inventoryUI.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;

        // Ocultar el inventario
        inventoryUI.SetActive(false);
    }
}