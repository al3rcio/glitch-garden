using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    EnemySpawner myLane;
    Animator animator;
    GameObject projectilesParent;
    const string PROJECTILES_PARENT_NAME = "Projectiles";

    private void Start()
    {
        CreateProjectilesParent();
        animator = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void CreateProjectilesParent()
    {
        projectilesParent = GameObject.Find(PROJECTILES_PARENT_NAME);
        if (!projectilesParent)
        {
            projectilesParent = new GameObject(PROJECTILES_PARENT_NAME);
        }
    }

    private void SetLaneSpawner()
    {

        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>(); 

        foreach (EnemySpawner spawner in spawners)
        {
            // resolução do curso
            /*bool isClose = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isClose)
            {
                myLane = spawner;
            }*/
            float isZero = spawner.transform.position.y - transform.position.y; // minha resolução
            if (isZero == 0)
            {
                myLane = spawner;
            }
        }

    }

    private bool IsAttackerInLane()
    {
        if (myLane.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity) as GameObject;
        newProjectile.transform.parent = projectilesParent.transform;
    }
}
