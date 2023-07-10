using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Outside : MonoBehaviour
{
    public string Calle;
    public Dialogo dialogo; 

    private bool playerInRange = false;
    private GameObject Player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Player = other.gameObject; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Player = null; 
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.W) && Player != null && !dialogo.didDialogueStart)
        {
            SceneManager.LoadScene(Calle);
        }
    }
}
