using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    private float spawnDelay = 3f;
    private float currentTime = 0f;

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
        // Instantiate the enemy prefab at the spawner's position
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
