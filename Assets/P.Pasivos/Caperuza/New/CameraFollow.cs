using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Referencia al Transform del personaje a seguir
    public float maxX;              // L�mite m�ximo en el eje X
    public float minX;              // L�mite m�nimo en el eje X
    public float maxY;              // L�mite m�ximo en el eje Y
    public float minY;              // L�mite m�nimo en el eje Y

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            // Obtener la posici�n actual de la c�mara
            Vector3 currentPosition = transform.position;

            // Obtener la posici�n del personaje a seguir
            Vector3 targetPosition = target.position;

            // Aplicar los l�mites m�ximos y m�nimos a la posici�n del personaje
            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

            // Mantener la posici�n z de la c�mara
            targetPosition.z = currentPosition.z;

            // Actualizar la posici�n de la c�mara
            transform.position = targetPosition;
        }
    }
}
