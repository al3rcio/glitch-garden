using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    float levelTimer = 10f;
    bool finishGame = false;
    Slider gameTimer;
    LevelController levelController;

    private void Start()
    {
        gameTimer = GetComponent<Slider>();
        levelController = FindObjectOfType<LevelController>();
    }
    void Update()
    {
        Timer();
        if (!finishGame)
            HasEnd();
    }

    public void Timer()
    {
        gameTimer.value = Time.timeSinceLevelLoad / levelTimer;
    }

    public bool HasEnd()
    {
        bool hasEnd = (Time.timeSinceLevelLoad >= levelTimer);
        if (hasEnd)
        {
            Debug.Log("time has end!");
            finishGame = true;
            levelController.HasTimerEnd();
            return true;
        }
        return false;
    }
}
