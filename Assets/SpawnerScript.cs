using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnInterval = 0.12f; 

    void Start()
    {
        InvokeRepeating("SpawnCube", 0f, spawnInterval);
    }

    void SpawnCube()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(0, 256), 5, Random.Range(0, 256));
        Instantiate(cubePrefab, randomSpawnPosition, Quaternion.identity);
    }
}
