using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneChanger : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Main");
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}