using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private Health enemyHealth;

    private int randomEnemyIndex;
    
    private float spawnDelay = 3f;
    private float currentTime = 0f;

    private void Start()
    {
        enemyHealth = enemyPrefabs[randomEnemyIndex].GetComponent<Health>();   
    }

    private void Update()
    {
        if(!GlobalVars.enemySpawned)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= spawnDelay)
            {
                SpawnEnemy();
                currentTime = 0f;
            }
        }        
    }

    private void SpawnEnemy()
    {
        randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
        // Instantiate the enemy prefab at the spawner's position
        Instantiate(enemyPrefabs[randomEnemyIndex], transform.position, Quaternion.identity);
    }
}
