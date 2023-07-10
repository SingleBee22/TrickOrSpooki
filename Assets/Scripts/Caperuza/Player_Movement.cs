using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del jugador

    private void Update()
    {
        // Obtener la entrada del teclado
        float moveInput = Input.GetAxis("Horizontal");

        // Calcular el movimiento del jugador
        Vector3 movement = new Vector3(moveInput * speed, 0f, 0f);

        // Aplicar el movimiento al jugador
        transform.position += movement * Time.deltaTime;
    }
}
