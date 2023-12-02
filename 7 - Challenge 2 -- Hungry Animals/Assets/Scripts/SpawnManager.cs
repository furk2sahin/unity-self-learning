using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject spawnedAnimalPrefab;
    public float spawnRangeX = 10;
    public float spawnPozZ = 20;
    private float startDelay = 2;
    public float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomAnimal()
    {
        spawnedAnimalPrefab = animalPrefabs[Random.Range(0, animalPrefabs.Length)];
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPozZ);
        Instantiate(
            spawnedAnimalPrefab,
            spawnPosition,
            spawnedAnimalPrefab.transform.rotation
        );
    }
}
