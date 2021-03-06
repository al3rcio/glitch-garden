using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float health = 100f;
   
    
    public void DealDamage(float damage)
    {
        health = health - damage;
        Debug.Log(health);
        if (health <= 0)
        {
            Debug.Log("damages " + gameObject.name);
            Destroy(gameObject);
        }
    }

}
