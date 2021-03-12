using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilRobot : MonoBehaviour
{
    Attacker attack;
    
    private void Start()
    {
        attack = GetComponent<Attacker>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            attack.Attack(otherObject);   
        }
    }
}
