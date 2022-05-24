using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerUpPrefab;

    float xSpawnRange = 12;
    float zSpawnRange = 12;
    public int enemyCount;
    public int wave = 1;
    void Start()
    {
        SpawnEnemy(wave);
        SpawnPowerUp();
    }

    
    void Update()
    {
        enemyCount = FindObjectsOfType<MovingEnemy>().Length;
        if(enemyCount == 0){
            wave++;
            SpawnEnemy(wave);
            SpawnPowerUp();
        }
    }

    void SpawnEnemy(int spawnEnemy){
        for(int i = 0; i< spawnEnemy; i++){
            int randomIndex = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomIndex], GenerateSpawnPosition(), enemies[randomIndex].gameObject.transform.rotation);
        }

    }

    void SpawnPowerUp(){
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    Vector3 GenerateSpawnPosition(){
        float spawnPositionX = Random.Range(-xSpawnRange, xSpawnRange);
        float spawnPositionZ = Random.Range(-zSpawnRange, zSpawnRange);

        Vector3 randomSpawn = new Vector3(spawnPositionX, .5f, spawnPositionZ);

        return randomSpawn;
    }
}
