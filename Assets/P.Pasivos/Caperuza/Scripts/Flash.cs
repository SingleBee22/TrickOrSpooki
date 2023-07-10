using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flash : MonoBehaviour
{
    public float opacidadClick = 0.6f; // Opacidad durante el clic (0.0f a 1.0f)
    public float duracionClick = 0.5f; // Duración del cambio de opacidad y activación del Collider2D en segundos

    private SpriteRenderer spriteRenderer; // Referencia al componente SpriteRenderer
    public Light2D l2D;

    private Collider2D objetoCollider; // Referencia al componente Collider2D
    private float intensidadO = 0.4f; // Color original del objeto

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        objetoCollider = GetComponent<Collider2D>();
        objetoCollider.enabled = false; // Desactivar el Collider2D al iniciar
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CambiarOpacidadYActivarCollider());
        }
    }

    private System.Collections.IEnumerator CambiarOpacidadYActivarCollider()
    {
        l2D.intensity = opacidadClick;
        objetoCollider.enabled = true;

        yield return new WaitForSeconds(duracionClick);

        l2D.intensity = intensidadO;
        objetoCollider.enabled = false;
    }
}