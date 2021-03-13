using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    float loadTime = 3f;
    int currentScene;
    LifeDisplay life;

    
    void Start()
    {
        life = FindObjectOfType<LifeDisplay>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 0)
        {
            StartCoroutine(LoadingStart());
        }
        
    }
    void Update()
    {
        if (life.GetLife() <= 0)
        {
            StartCoroutine(LoadingRestart());
        }
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
        LoadRestart();
    }

    public void LoadRestart()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
