using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[Header("Delay Spawns")]
    /*[SerializeField]*/ float delayMin = 2f;
    /*[SerializeField]*/ float delayMax = 10f;

    [Header("Enemies")]
    [SerializeField] Attacker enemy;

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
        Attacker attacker = Instantiate(enemy, transform.position, Quaternion.identity) as Attacker;
        attacker.transform.parent = transform;
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
