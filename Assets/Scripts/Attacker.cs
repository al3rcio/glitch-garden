using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    float currentSpeed = 7f;
    Animator animator;
    [SerializeField] GameObject currentTarget;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
    public void NotAttacking()
    {
        animator.SetBool("isAttacking", false);
    }

    public void Attack(GameObject target)
    {
        Debug.Log("attacking!!!");
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeTarget(float damage)
    {
        if (!currentTarget) { return; }

        Health health = currentTarget.GetComponent<Health>();

        if (health)
        {
            health.DealDamage(damage);
            if (health.GetDie())
            {
                animator.SetBool("isAttacking", false);
            }
        }
    }
}
