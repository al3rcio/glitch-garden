using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float delayMin = 10f;
    float delayMax = 10f;

    [Header("Enemies")]
    [SerializeField] Attacker[] enemies;

    LevelController levelController;

    bool isSpawning = true;
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        StartCoroutine(StartSpawning());
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    IEnumerator StartSpawning()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(delayMin, delayMax));
            Spawn();
        }
    }
    public void Spawn()
    {
        int randomSpawn = Random.Range(0, enemies.Length);
        Attacker attacker = Instantiate(enemies[randomSpawn], transform.position, Quaternion.identity) as Attacker;
        attacker.transform.parent = transform;
        levelController.AttackerSpawned();

    }
}