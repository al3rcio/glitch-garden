using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFall : MonoBehaviour
{
    LifeDisplay lifeDisplay;

    private void Start()
    {
        lifeDisplay = FindObjectOfType<LifeDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        lifeDisplay.BreakCount();
    }

    /*public int BreakCount()
    {
        breakCount++;
        return breakCount;
    }*/
}
