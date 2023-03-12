using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textHolder;
    public Text text1;
    public static bool NextTextBox = false;

    void Start()
    {
        Color color = text1.color;
        color.a = 0.01f;
        text1.color = color;
        StartCoroutine(FadeTextToFullAlpha(1f, text1));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (text1.color.a > 0.0f)
            {
                StartCoroutine(FadeTextToZeroAlpha(1f, text1));
            }
            Debug.Log(NextTextBox);
        }

        if (text1.color.a == 0.0f)
            {
            Debug.Log("text1 is completely transparent");
            NextTextBox = true;
            textHolder.SetActive(false);
            }
        else
        {
            Debug.Log("text1 is not completely transparent yet");
        }
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
 
    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
    while (i.color.a > 0.05f) // set the threshold to 0.05f (or any other value you prefer)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
        yield return null;
    }
    i.color = new Color(i.color.r, i.color.g, i.color.b, 0); // set the alpha to 0
    }
}
