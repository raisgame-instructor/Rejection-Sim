using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public string SceneName;
    public void Restart()
    {
        SceneManager.LoadScene(SceneName);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
