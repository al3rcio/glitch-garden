using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[Header("Delay Spawns")]
    /*[SerializeField]*/ float delayMin = 1f;
    /*[SerializeField]*/ float delayMax = 4f;

    [Header("Enemies")]
    [SerializeField] Attacker[] enemies;

    bool isSpawning = true;
    void Start()
    {
        StartCoroutine(StartSpawning());
    }
    IEnumerator StartSpawning()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(delayMin, delayMax));
            // SpawnEnemies();
            Spawn();
        }
    }

    /* private void SpawnEnemies()
     {
         Spawn();
     }
 */
    private void Spawn()
    {
        int randomSpawn = Random.Range(0, enemies.Length);
        Attacker attacker = Instantiate(enemies[randomSpawn], transform.position, Quaternion.identity) as Attacker;
        attacker.transform.parent = transform;
    }
}
