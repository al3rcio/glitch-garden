using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Delay Spawns")]
    [SerializeField] float delayMin = 1f;
    [SerializeField] float delayMax = 5f;

    [Header("Enemies")]
    [SerializeField] GameObject enemy;

    bool isSpawning = true;



    IEnumerator StartSpawning()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(delayMin, delayMax));
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
