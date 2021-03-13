using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeDisplay : MonoBehaviour
{
    int life = 10;
   // int breakCount = 0;
    Text textLife;

    private void Start()
    {
        textLife = GetComponent<Text>();
    }
    private void Update()
    {
        DisplayLife();
    }

    private void DisplayLife()
    {
        textLife.text = life.ToString();
        if (life <= 0)
        {
            textLife.text = "YOU LOSE";
            textLife.color = Color.red;
            //textLife.transform.position = new Vector3(31, -68, 0);
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
