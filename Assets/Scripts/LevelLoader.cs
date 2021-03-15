using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    float loadTime = 3f;
    int currentScene;
    LifeDisplay life;

    public void Start()
    {
        life = FindObjectOfType<LifeDisplay>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 0)
        {
            StartCoroutine(LoadingStart());
        }
        
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    IEnumerator LoadingStart()
    {
        yield return new WaitForSeconds(loadTime);
        LoadNextScene();
    }

    IEnumerator LoadingRestart()
    {
        yield return new WaitForSeconds(loadTime);
        LoadStartScreen();
    }

    public void LoadStartScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
