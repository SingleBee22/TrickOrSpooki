using UnityEngine;

public class Linterna_Pickup : MonoBehaviour
{
    public GameObject Linternameson; 
    public GameObject linternaInfo;
    public GameObject Temporal; 

    private bool playerInRange = false;
    private bool linternaRecogida = false;
    private GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !linternaRecogida)
        {
            playerInRange = true;
            Player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            Player = null;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !linternaRecogida)
        {
            RecogerLinterna();
        }
    }

    private void RecogerLinterna()
    {
        linternaRecogida = true;
        Linternameson.SetActive(false);
        linternaInfo.SetActive(true);
    }
}
