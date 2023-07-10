using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Sprite atksprite;
    public SpriteRenderer sr;
    public float damagePerSecond = 1;
    public float detachDelay = 2f;

    private bool isAttached = false;
    private float detachTimer = 0f;
    private Char_Movement playerController;
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerController = FindObjectOfType<Char_Movement>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        if(playerController.transform.position.x - this.transform.position.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        if (playerController.IsLockPlayer(this))
        {
            // Reduce la salud del jugador
            playerHealth.TakeDamage(damagePerSecond * Time.deltaTime);

            // Comienza a contar el tiempo para soltar al jugador
            /*
            detachTimer += Time.deltaTime;
            if (detachTimer >= detachDelay)
            {
                isAttached = false;
                playerController.UnlockPlayer();
            }
            */
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sr.sprite = atksprite;
            playerController.LockPlayer(this);
            detachTimer = 0f;
        }
    }
}