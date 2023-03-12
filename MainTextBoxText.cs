using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainTextBoxText : MonoBehaviour
{
    // Start is called before the first frame update
    public float letterDelay = 0.1f; // The delay between each letter being revealed
    public Text text1; // The Text component that will display the text
    public Text text2; // The Text component that will display the text
    public bool TextRevealed = false;

    private string fullText; // The full text to be displayed in the Text component
    private Prime_Minister_Script pmScript; // A reference to the Prime_Minister_Script object
    void Start()
    {
        fullText = text1.text; // Store the full text
        pmScript = FindObjectOfType<Prime_Minister_Script>(); // Gets a reference to the Prime_Minister_Script object
        text1.text = ""; // Clear the text in the Text component
        
    }

    void Update()
    {
        if (!TextRevealed && pmScript.hasStopped == true)
    {
        StartCoroutine(RevealText(text1)); // Start the coroutine to reveal the text
    }
    if (Input.GetKey(KeyCode.Mouse0) && TextRevealed == true)
    {
        fullText = text2.text; // Store the full text
        text1.enabled = false; // Hide text1
        text2.text = ""; // Clear the text in the Text component
        StartCoroutine(RevealText(text2)); // Start the coroutine to reveal the text
    }
       
    }
   private IEnumerator RevealText(Text t)
    {
        TextRevealed = true;
        for (int i = 0; i < fullText.Length; i++)
        {
            t.text += fullText[i]; // Add the next letter to the Text component
            yield return new WaitForSeconds(letterDelay); // Wait for the letter delay before revealing the next letter
        }
    }
}
