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
            if (collision.GetComponent<GhostMovement>())
            {
                collision.GetComponent<GhostMovement>().enabled = false;
                StartCoroutine(ReturnToNormal(collision.GetComponent<GhostMovement>()));
            }
            // Desactiva la detección del jugador en el fantasma cuando entra en el área de luz
            // ghostMovement.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<GhostMovement>()) {
                collision.GetComponent<GhostMovement>().enabled = false;
            }
            // Activa la detección del jugador en el fantasma cuando sale del área de luz
            //ghostMovement.enabled = true;
        }
    }

    public IEnumerator ReturnToNormal(GhostMovement gm)
    {
        yield return new WaitForSeconds(1);
        gm.enabled = true;

    }
}