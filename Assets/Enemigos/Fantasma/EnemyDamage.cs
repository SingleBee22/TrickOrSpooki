using UnityEngine;
using UnityEngine.Events;

public class EnemyDamage : MonoBehaviour
{
    public float damageAmount = 2f;
    public float cooldownTime = 1f;
    public UnityEvent onPlayerDamage;

    private float lastDamageTime;

    private void Start()
    {
        lastDamageTime = -cooldownTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Time.time - lastDamageTime >= cooldownTime)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                onPlayerDamage.Invoke();
                lastDamageTime = Time.time;
            }
        }
    }
}
