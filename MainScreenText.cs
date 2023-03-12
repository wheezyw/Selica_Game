using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenText : MonoBehaviour
{
    public GameObject textHolder;
    public Text text1;
    public TextScript1 textScript1;
    private bool fadeInStarted = false;

    void Start()
    {
    }

    void Update()
    {
        bool nextTextBoxValue = TextScript1.NextTextBox;
        if (nextTextBoxValue&& !fadeInStarted)
        {
            fadeInStarted = true;
            textHolder.SetActive(true);
            StartCoroutine(FadeTextToFullAlpha(1f, text1));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) &&nextTextBoxValue )
        {
            if (text1.color.a > 0.0f)
            {
                StartCoroutine(FadeTextToZeroAlpha(1f, text1));
            }
        }

        if (text1.color.a == 0.0f)
        {
            fadeInStarted = false;
            TextScript1.NextTextBox = false;
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
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}