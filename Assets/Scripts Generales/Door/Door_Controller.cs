using System;
using System.Collections.Generic;
using UnityEngine;

public class Door_Controller : MonoBehaviour
{
    public List<Transform> levelDeph;
    public int currentDeph = 0;
    public Door_Controller destination;

    private bool playerInRange = false;
    private GameObject playerObject; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            playerObject = null;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.W) && playerObject != null)
        {
            // Teletransporta al jugador al otro lado de la puerta
            // playerObject.transform.position = destination.transform.position;
            for (int i = 0; i < levelDeph.Count; i++)
            {
                levelDeph[i].gameObject.SetActive(false);
            }
            levelDeph[destination.currentDeph].gameObject.SetActive(true);
        }
    }
}
