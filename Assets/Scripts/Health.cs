using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    float health = 100f;
   
    
    public void DealDamage(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            DeathVFX();
            Destroy(gameObject);
        }
    }

    public void DeathVFX()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(vfx, 1f);
    }

}
