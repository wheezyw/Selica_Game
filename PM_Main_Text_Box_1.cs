using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PM_Main_Text_Box_1 : MonoBehaviour
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
    public  bool[] textRevealed; // An array to keep track of which text boxes have been revealed
    private bool buttonsizeIncreased = false;
    private bool firstInstanceFinished = false;

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

        if (firstInstanceFinished && !textRevealed[0])
        {
            myButtonImage.gameObject.SetActive(true);
            StartCoroutine(RevealText(textBoxes[0], fullTexts[0]));
            textRevealed[0] = true;
        }

        if (firstInstanceFinished && textRevealed[0] && Input.GetMouseButtonDown(0))
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
    }

    private IEnumerator RevealText(Text t, string fullText)
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            t.text += fullText[i];
            yield return new WaitForSeconds(letterDelay);
        }
    }

    // This function will be called from the first instance when its text has been fully revealed
    public void FirstInstanceFinished()
    {
        firstInstanceFinished = true; 
    }
}
