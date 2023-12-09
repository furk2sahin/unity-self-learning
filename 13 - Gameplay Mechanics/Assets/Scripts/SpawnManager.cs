using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] powerUps;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.livingEnemyCount == 0) {
            SpawnEnemyWave();
            SpawnPowerup();
        }
    }

    private void SpawnEnemyWave() {
        for(int i = 0; i < gameController.waveNumber; i++) {
            Instantiate(enemyPrefab, GetSpawnPosition(), enemyPrefab.transform.rotation);
        }
        gameController.livingEnemyCount = gameController.waveNumber;
        gameController.waveNumber += 1;
    }

    private void SpawnPowerup() {
        GameObject powerup = powerUps[Random.Range(0, powerUps.Length)];
        Instantiate(powerup, GetSpawnPosition(), powerup.transform.rotation);
    }

    private Vector3 GetSpawnPosition() {
        float spawnPositionX = Random.Range(-gameController.autoSpawnRange, gameController.autoSpawnRange);
        float spawnPositionZ = Random.Range(-gameController.autoSpawnRange, gameController.autoSpawnRange);
        return new Vector3(spawnPositionX, 0, spawnPositionZ);
    }

}
