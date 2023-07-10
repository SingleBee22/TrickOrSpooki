using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    private GhostMovement ghostMovement;

    private void Start()
    {
        // Busca el componente GhostMovement en el objeto del fantasma
        ghostMovement = FindObjectOfType<GhostMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Desactiva la detecci�n del jugador en el fantasma cuando entra en el �rea de luz
            ghostMovement.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Activa la detecci�n del jugador en el fantasma cuando sale del �rea de luz
            ghostMovement.enabled = true;
        }
    }
}