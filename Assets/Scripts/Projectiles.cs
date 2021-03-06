using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] float speedShoot = 1f;
    [SerializeField] float damage = 50f;

    public void Update()
    {
        ShootProjectile();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collides with " + collision.name);
        var dealDamage = collision.GetComponent<Health>();
        dealDamage.DealDamage(damage);
        Destroy(gameObject);
        
    }

    public void ShootProjectile()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speedShoot);
        // tentar fazer rotação projétil
        /*transform.Rotate(0.0f, 0.0f, 180.0f * Time.deltaTime * 1, Space.Self);
        transform.Rotate(Vector3.RotateTowards(transform.forward,  ))*/
    }
}
