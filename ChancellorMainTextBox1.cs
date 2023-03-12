using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChancellorMainTextBox1 : MonoBehaviour
{

    public Image myButtonImage;
    private Prime_Minister_Script pmScript;
    public float letterDelay = 0.1f;
    public  Text[] textBoxes; // An array of Text components for the text boxes
    public string[] fullTexts; // An array of strings for the full text of each text box
    public  bool[] pmMove;
    public  bool text1revealed = false;
    public  bool[] chancellorMove;
    public Vector3 buttonScaleOnText2Reveal;

    public GameObject Chancellor;

    public GameObject PM;
    public PM_Main_Text_Box_1 secondInstance;


    public  bool[] textRevealed; // An array to keep track of which text boxes have been revealed
    private bool buttonsizeIncreased = false;

    void Start()
    {
        if (myButtonImage != null)
        {
             myButtonImage.gameObject.SetActive(false);
        }
        pmScript = FindObjectOfType<Prime_Minister_Script>();
        textRevealed = new bool[textBoxes.Length]; // Initialize the textRevealed array
        Debug.Log(textRevealed.Length);
        for (int i = 0; i < textBoxes.Length; i++)
        {
            textBoxes[i].text = ""; // Clear the text in each text box
        }
    }

    void Update()
    {
        if (pmScript != null && pmScript.hasStopped&& !textRevealed[0])
        {
            StartCoroutine(RevealText(textBoxes[0], fullTexts[0]));
            textRevealed[0] = true;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("key click found");
            
        }
        if (textRevealed[0] && Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < textBoxes.Length; i++)
            {
                if (i>0 && textRevealed[i-1] && !textRevealed[i])
                {
                    textBoxes[i-1].enabled = false;
                    StartCoroutine(RevealText(textBoxes[i], fullTexts[i]));
                    textRevealed[i] = true;
                    break;
                }
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && textRevealed[0] && !buttonsizeIncreased)
        {
            myButtonImage.rectTransform.sizeDelta = new Vector2(myButtonImage.rectTransform.sizeDelta.x, myButtonImage.rectTransform.sizeDelta.y * 1.5f);
            buttonsizeIncreased = true;
        }

        if (pmScript.hasStopped == true)
        {
            myButtonImage.gameObject.SetActive(true);
        }
        
        if (textRevealed[1] && text1revealed == false && Input.GetMouseButtonDown(0))
        {
            pmMove = addTrueElement(pmMove);
            Debug.Log(pmMove[0]);
            text1revealed = true;

            // Call the FirstInstanceFinished() function of the second instance
            secondInstance.FirstInstanceFinished();
            Debug.Log("Second Instance Started");
        }
    }

    private IEnumerator RevealText(Text t, string fullText)
    {
        Debug.Log("Text Is Being Revealed");
        for (int i = 0; i < fullText.Length; i++)
        {
            t.text += fullText[i];
            yield return new WaitForSeconds(letterDelay);
        }
    }
    

    private IEnumerator ShowTextBoxesWithDelay(float delayTime)
    {
        bool allRevealed = true; // Initialize the flag to true
        for (int i = 0; i < textBoxes.Length; i++)
        {
            if (!textRevealed[i])
            {
                allRevealed = false; // If at least one text box is not revealed, set the flag to false
                textBoxes[i - 1].enabled = false;
                StartCoroutine(RevealText(textBoxes[i], fullTexts[i]));
                textRevealed[i] = true;
                yield return new WaitForSeconds(delayTime);
            }
        }
        if (allRevealed) // If all text boxes are revealed, break out of the loop
        {
            yield break;
        }
    }

    private bool[] addTrueElement(bool[] array)
    {
        bool[] newArray = new bool[array.Length + 1]; // create a new bool array with one extra element
        array.CopyTo(newArray, 0); // copy the values from pmMove to the new array
        newArray[array.Length] = true; // set the new element to true
        return newArray; // return the new array
    }

}