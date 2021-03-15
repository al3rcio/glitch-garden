using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int attackersCount = 0;
    bool hasTimerEnd = false;
    LevelLoader levelLoader;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        levelLoader = GetComponent<LevelLoader>();
    }

    public void AttackerSpawned()
    {
        attackersCount++;
        Debug.Log("Spawned: " + attackersCount);
    }

    public void AttackerKilled()
    {
        attackersCount--;
        Debug.Log("Killed: " + attackersCount);
        if (attackersCount <= 0 && hasTimerEnd)
        {
            StartCoroutine(HandleWin());
        }
    }

    IEnumerator HandleWin()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5f);
        levelLoader.LoadNextScene();
    }

    public void HandleLose()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void HasTimerEnd()
    {
        hasTimerEnd = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner spawner in spawners)
        { 
            spawner.StopSpawning();
        }
    }


}
