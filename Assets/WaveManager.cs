using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWaveSize, enemiesSpawned, enemiesAlive;
    public int currentWaveNumber = 0;

    float spawnInterval = 2.5f;

    public Transform spawnpoint;
    public GameObject[] enemyObj;

    GameObject waveStarter;

    public bool waveActive = false;

    // Start is called before the first frame update
    private void Awake()
    {
        waveStarter = GameObject.Find("StartWaveButton");
        currentWaveSize += 5;
        currentWaveNumber += 1;

        Debug.Log($"Wave {currentWaveNumber} started. Wave size: {currentWaveSize}.");
    }

    public void StartWave()
    {
        waveActive = true;
        waveStarter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (waveActive)
        {
            if (enemiesSpawned < currentWaveSize && Time.time >= spawnInterval)
            {
                StartCoroutine(SpawnEnemy());
                spawnInterval = Time.time + spawnInterval;
            }
            else if (enemiesSpawned == currentWaveSize && enemiesAlive == 0)
            {
                waveActive = false;
                waveStarter.SetActive(true);

                UpdateWaveStats();
            }
        }
    }

    void UpdateWaveStats()
    {
        currentWaveNumber++;
        currentWaveSize += 5 * currentWaveNumber;

        if (spawnInterval > 0)
        {
            spawnInterval -= (spawnInterval / 10);
        }
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(enemyObj[0], spawnpoint.position, Quaternion.identity);
        Debug.Log("Enemy spawned!");
        enemiesAlive++;
        enemiesSpawned++;
        yield return new WaitForSeconds(spawnInterval);
    }
}
    