using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeDisplay : MonoBehaviour
{
    /*[SerializeField]*/ int life = 2;
    int dangerLife;
    Text textLife;
    LevelController levelController;
    

    private void Start()
    {
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

    public int BreakCount()
    {
        //breakCount++;
        life -= 1;
        return life;
    }

    public int GetLife() { return life; }
}
