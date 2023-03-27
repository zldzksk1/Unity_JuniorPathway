using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;

    public GameObject powerupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);    
        Instantiate(powerupPrefab, GenerateRespawnPosition(), powerupPrefab.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateRespawnPosition(), powerupPrefab.transform.rotation);

        }
 
    }

    void SpawnEnemyWave(int enemiesToSpaw)
    {
        for(int i = 0; i < enemiesToSpaw; i++)
        {
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomEnemy], GenerateRespawnPosition(), enemyPrefabs[randomEnemy].transform.rotation);    
        }
    }

    private Vector3 GenerateRespawnPosition()
    {  
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 RandomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return RandomPos;
    }
}
