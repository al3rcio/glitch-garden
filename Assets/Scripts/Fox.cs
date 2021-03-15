using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    Attacker attack;
    Animator animator;
    private void Start()
    {
        attack = GetComponent<Attacker>();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.tag == "Gravestone")
        {
            Jump();
        }
        else if (otherObject.GetComponent<Defender>())
        {
            attack.Attack(otherObject);
        }
    }

    private void Jump()
    {
        animator.SetTrigger("jumpTrigger");
    }
}
