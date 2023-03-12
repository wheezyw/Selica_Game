using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    public void LoadNextScene()
{
    SceneManager.LoadScene("First_Day");
    Debug.Log("Scene is loaded");
}
}
