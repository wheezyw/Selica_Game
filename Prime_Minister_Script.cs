using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prime_Minister_Script : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed = 10f;
    public float stopTime1 = 4f;
    public float startTime1 = 2f;
    public float stopTime2 = 4f;
    public float startTime2 = 2f;
    public bool PMspeech1;
    public bool hasStopped = false; // A public bool to indicate if the character has stopped moving
    private bool text1 = false;

    public static bool[] pmMove;

    public ChancellorMainTextBox1 chTextBox1_script;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DelayedMove(startTime1)); // Starts the DelayedStop coroutine
        StartCoroutine(DelayedStop(stopTime1)); // Starts the DelayedStop coroutine
    }

    // Update is called once per frame
    void Update()
   {
        bool[] pmMoveArray = chTextBox1_script.pmMove;
        Debug.Log(pmMoveArray.Length);
        if (pmMoveArray != null && pmMoveArray.Length > 0 && pmMoveArray[0] && text1 == false)
        {
            Debug.Log("Movement");
            StartCoroutine(DelayedMove(startTime2)); // Starts the DelayedStop coroutine
            StartCoroutine(DelayedStop(stopTime2)); // Starts the DelayedStop coroutine
            text1 = true;
        }
        
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
        hasStopped = true; // Sets hasStopped to true when the character stops moving
    
    }
}
