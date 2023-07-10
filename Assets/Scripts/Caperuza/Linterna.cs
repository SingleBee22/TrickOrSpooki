using UnityEngine;

public class Linterna : MonoBehaviour
{
    public GameObject jugador;  // Referencia al objeto jugador
    public float velocidadRotacion = 5f;  // Velocidad de rotación alrededor del jugador

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;  // Asegúrate de que la posición Z sea 0 para un juego 2D

        // Calcula la dirección del cursor respecto al jugador
        Vector3 direccion = mousePosition - jugador.transform.position;
        direccion.Normalize();

        // Calcula el ángulo de rotación alrededor del jugador
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg - 90f;

        // Aplica la rotación alrededor del jugador
        transform.position = jugador.transform.position;
        transform.rotation = Quaternion.Euler(0f, 0f, angulo);
    }
}
