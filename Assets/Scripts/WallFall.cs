using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFall : MonoBehaviour
{
    LifeDisplay lifeDisplay;
    LevelController levelController;

    private void Start()
    {
        lifeDisplay = FindObjectOfType<LifeDisplay>();
        levelController = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        lifeDisplay.BreakCount();
        levelController.AttackerKilled();
    }



  
}
