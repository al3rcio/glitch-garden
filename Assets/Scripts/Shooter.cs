using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;

    public void Fire()
    {
        Transform child = GetComponentInChildren<Transform>().GetChild(0);
        Instantiate(projectile, child.transform.position, Quaternion.identity);
        //projectiles.ShootProjectile();
    }
}
