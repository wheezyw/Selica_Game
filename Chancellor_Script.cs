using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chancellor_Script : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed = 10f;
    public bool Chspeech1;
    public float stopTime1 = 4f;
    public float startTime1 = 2f;
    public bool hasStopped = false; // A public bool to indicate if the character has stopped moving

    void Start()
    {
 rb =   GetComponent<Rigidbody2D>();
        StartCoroutine(DelayedMove(startTime1)); // Starts the DelayedStop coroutine
        StartCoroutine(DelayedStop(stopTime1)); // Starts the DelayedStop coroutine
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DelayedMove(float t)
    {
        yield return new WaitForSeconds(t); // waits for 2 seconds
        rb.velocity = new Vector2(speed, 0f); // moves the sprite to the right
    }

    IEnumerator DelayedStop(float t)
    {
        yield return new WaitForSeconds(t); // Waits for t seconds
        rb.velocity = new Vector2(0f, 0f); // Stops the movement of the character
    }
}
