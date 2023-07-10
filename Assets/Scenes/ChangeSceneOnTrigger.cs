using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTrigger : MonoBehaviour
{
    public string Mansion; // Nombre de la escena a la que quieres cambiar

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Comprueba si el objeto que colisiona tiene la etiqueta "Player"
        {
            SceneManager.LoadScene(Mansion); // Cambia a la escena especificada por su nombre
        }
    }
}
