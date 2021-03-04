using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    float loadTime = 3f;
    int currentScene;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    IEnumerator LoadingStart()
    {
        yield return new WaitForSeconds(loadTime);
        LoadNextScene();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 0)
        {
            StartCoroutine(LoadingStart());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
