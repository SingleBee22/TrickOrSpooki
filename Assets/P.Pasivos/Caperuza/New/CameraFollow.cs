using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Referencia al Transform del personaje a seguir
    public float maxX;              // Límite máximo en el eje X
    public float minX;              // Límite mínimo en el eje X
    public float maxY;              // Límite máximo en el eje Y
    public float minY;              // Límite mínimo en el eje Y

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            // Obtener la posición actual de la cámara
            Vector3 currentPosition = transform.position;

            // Obtener la posición del personaje a seguir
            Vector3 targetPosition = target.position;

            // Aplicar los límites máximos y mínimos a la posición del personaje
            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

            // Mantener la posición z de la cámara
            targetPosition.z = currentPosition.z;

            // Actualizar la posición de la cámara
            transform.position = targetPosition;
        }
    }
}
