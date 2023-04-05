using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject ringPrefab;
    private float spawnRange = 180;
    public int enemyCount;
    public int ringCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnRing(1);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }

        ringCount = FindObjectsOfType<SpinRingX>().Length;

        if(ringCount == 0)
        {
            SpawnRing(1);
        }
    }
    
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            float spawnPosX = Random.Range(-spawnRange, spawnRange);
            float spawnPosZ = Random.Range(-100, 415);
            Vector3 randomPos = new Vector3(spawnPosX, -47, spawnPosZ);
            Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
        }
    }

    void SpawnRing(int ringsToSpawn)
    {
        for (int i = 0; i < ringsToSpawn; i++)
        {
            float spawnPosX = Random.Range(-spawnRange, spawnRange);
            float spawnPosZ = Random.Range(-20, 340);
            Vector3 randomPos = new Vector3(spawnPosX, -47, spawnPosZ);
            Instantiate(ringPrefab, randomPos, ringPrefab.transform.rotation);
        }
    }
}
