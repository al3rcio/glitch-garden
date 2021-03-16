using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeDisplay : MonoBehaviour
{
    public float baseLife = 3f;
    float life;
    public float damage = 1f;
    float dangerLife;
    Text textLife;
    LevelController levelController;
    

    private void Start()
    {
        life = baseLife - PlayerPrefsController.GetDifficulty();
        textLife = GetComponent<Text>();
        levelController = FindObjectOfType<LevelController>();
        dangerLife = life / 2;
    }
    private void Update()
    {
        DisplayLife();
    }

    private void DisplayLife()
    {
        textLife.text = life.ToString();
        if (life <= dangerLife)
        {
            textLife.color = Color.red;                   
        }
        if (life <= 0)
        {
            life = 0;
            levelController.HandleLose();
        }
    }

    public float BreakCount()
    {
        life -= damage;
        return life;
    }

    public float GetLife() { return life; }
}
