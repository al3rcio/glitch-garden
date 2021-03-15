using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] float health;
    bool hasDie = false;
    LevelController levelController;

    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }


    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        DeathVFX();
        Destroy(gameObject);
        hasDie = true;
        if (gameObject.GetComponent<Attacker>())
        {
            levelController.AttackerKilled();
        }
    }

    public bool GetDie() { return hasDie; }


    public void DeathVFX()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(vfx, 1f);
    }

}
