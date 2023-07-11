using UnityEngine;

public class Mcc : MonoBehaviour
{
    public Murcielago murcielago;
    public Collider2D activationCollider;

    private void Start()
    {
        murcielago = GetComponentInParent<Murcielago>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == activationCollider)
        {
            murcielago.Activate();
        }
    }
}
