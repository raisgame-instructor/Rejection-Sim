using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string StartScene;
    public void StartButton()
    {
        SceneManager.LoadScene(StartScene);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
