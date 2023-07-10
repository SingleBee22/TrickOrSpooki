using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float floatAmplitude = 1f;    // Amplitud del movimiento de flotación
    public float floatFrequency = 1f;    // Frecuencia del movimiento de flotación
    private float floatTimer = 0f;       // Temporizador para el movimiento de flotación
    private Vector3 startingPosition;    // Posición inicial del enemigo
    public float speed = 3f;
    public float returnSpeed = 3f;
    public float minDistance = 0.1f;


    private Transform player = null;
    private bool isFollowing = false;
    private bool isReturning = false;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (isFollowing)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
            }
        }
        else
        {
            if (isReturning)
            {
                Vector3 direction = (startingPosition - transform.position).normalized;
                transform.position += direction * returnSpeed * Time.deltaTime;
                if (Vector3.Distance(transform.position, startingPosition) < minDistance)
                {
                    floatTimer = 0;
                    isReturning = false;
                }
            }
            else
            {
                LoopMovement();
            }
        }
    }

    void LoopMovement()
    {
        floatTimer += Time.deltaTime; // floatTimer = floatTimer + Time.deltaTime;
        float yOffset = Mathf.Sin(floatTimer * floatFrequency) * floatAmplitude;
        float xOffset = Mathf.Sin(floatTimer * floatFrequency * 0.5f) * floatAmplitude;
        transform.position = startingPosition + new Vector3(xOffset, yOffset, 0f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Human")
        {
            player = collision.transform;
            isFollowing = true;
            isReturning = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Human")
        {
            player = null;
            isFollowing = false;
            isReturning = true;
        }
    }
}
