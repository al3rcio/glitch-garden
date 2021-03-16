using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] GameObject projectileVFX;
    float speedShoot = 5f;
    float speedRotate = 200f;
    float waitRotate = 0.1f;
    [SerializeField] float damage;
    GameObject projectilesParent;
    const string PROJECTILES_PARENT_NAME = "Projectiles";

    private void Start()
    {
        CreateProjectilesParent();
    }

    private void CreateProjectilesParent()
    {
        projectilesParent = GameObject.Find(PROJECTILES_PARENT_NAME);
        if (!projectilesParent)
        {
            projectilesParent = new GameObject(PROJECTILES_PARENT_NAME);
        }
    }

    public void Update()
    {
        StartCoroutine(ShootProjectile());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var dealDamage = collision.GetComponent<Health>();
        var attacker = collision.GetComponent<Attacker>();

        if (attacker && dealDamage)
        {
            dealDamage.DealDamage(damage);
            ProjectileVFX();
            Destroy(gameObject);
        }
         
    }

    IEnumerator ShootProjectile()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speedShoot, Space.World);
        yield return new WaitForSeconds(waitRotate);
        transform.Rotate(Vector3.back, Time.deltaTime * speedRotate);
    }

    public void ProjectileVFX()
    {
        GameObject vfx = Instantiate(projectileVFX, transform.position, transform.rotation);
        Destroy(vfx, 1f);
    }
}
