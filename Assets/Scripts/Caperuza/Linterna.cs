using UnityEngine;

public class Linterna : MonoBehaviour
{
    public GameObject jugador;  // Referencia al objeto jugador
    public float velocidadRotacion = 5f;  // Velocidad de rotaci�n alrededor del jugador

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;  // Aseg�rate de que la posici�n Z sea 0 para un juego 2D

        // Calcula la direcci�n del cursor respecto al jugador
        Vector3 direccion = mousePosition - jugador.transform.position;
        direccion.Normalize();

        // Calcula el �ngulo de rotaci�n alrededor del jugador
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg - 90f;

        // Aplica la rotaci�n alrededor del jugador
        transform.position = jugador.transform.position;
        transform.rotation = Quaternion.Euler(0f, 0f, angulo);
    }
}
