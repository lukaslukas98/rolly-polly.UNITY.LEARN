using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public List<GameObject> enemyPrefabs;
    public GameObject enemyBossPrefab;
    
    private float spawnRange = 9f;
    private int spawnCount=0;
    public int enemyCount;

    public List<GameObject> powerUpPrefabs;

    public TextMeshProUGUI waveText;


    // Update is called once per frame
    void Update()
    {
        waveText.SetText("Wave: " + spawnCount);
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0 && !GameManager.isGameOver)
        {
            spawnCount++;
            SpawnEnemies(spawnCount);
            GameObject powerUp = powerUpPrefabs[Random.Range(0,powerUpPrefabs.Count)];

            Instantiate(powerUp, GenerateRandomSpawnPosition(), powerUp.transform.rotation);
            if (spawnCount == 5)
            {
                Instantiate(enemyBossPrefab, GenerateRandomSpawnPosition(), enemyBossPrefab.transform.rotation);
                enemyPrefabs.Add(enemyBossPrefab);
            }
        }
    }

    void SpawnEnemies(int loopCount)
    {
        for (int i = 0; i < loopCount; i++)
        {
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            Instantiate(enemyPrefab, GenerateRandomSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        float spawnPosX = Random.Range(spawnRange, -spawnRange);
        float spawnPosZ = Random.Range(spawnRange, -spawnRange);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}
