using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int damagePerSecond = 1;
    public float detachDelay = 2f;

    private bool isAttached = false;
    private float detachTimer = 0f;
    private Char_Movement playerController;

    private void Start()
    {
        playerController = FindObjectOfType<Char_Movement>();
    }

    private void Update()
    {
        if (isAttached)
        {
            // Reduce la salud del jugador
            playerController.TakeDamage(damagePerSecond * Time.deltaTime);

            // Comienza a contar el tiempo para soltar al jugador
            detachTimer += Time.deltaTime;
            if (detachTimer >= detachDelay)
            {
                isAttached = false;
                playerController.UnlockPlayer();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isAttached = true;
            playerController.LockPlayer();
            detachTimer = 0f;
        }
    }
}