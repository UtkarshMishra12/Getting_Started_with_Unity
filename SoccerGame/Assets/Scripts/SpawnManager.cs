using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    private float startdelay = 2.0f;
    private float spawndelay = 2.5f;
    public int enemyCount = 0;
    public int waveNumber = 1;
    public GameObject powerUp;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("spawnRandomEnemy", startdelay, spawndelay);
        spawnEnemyWave(waveNumber);
        Instantiate(powerUp, spawnPos(), powerUp.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            spawnEnemyWave(waveNumber);
            Instantiate(powerUp, spawnPos(), powerUp.transform.rotation);
        }
    }

    private Vector3 spawnPos()
    {
        float spawnX = Random.Range(-9, 9);
        float spawnZ = Random.Range(-9, 9);
        Vector3 spawnpos = new Vector3(spawnX, 0, spawnZ);
        return spawnpos;
    }

    void spawnEnemyWave(int enemiesToSpawn)
    {

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemy, spawnPos(), enemy.transform.rotation);
        }
    }
}
