using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextLevel()
    {
        // new level
        int nextSeceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int sceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        if (nextSeceneIndex <= sceneIndex)
        {
            SceneManager.LoadScene(nextSeceneIndex);
        }
        if (nextSeceneIndex > sceneIndex)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

