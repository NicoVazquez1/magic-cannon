using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject targetPrefab;     // Prefab of the target object to spawn
    public Transform[] spawnPoints;     // Array of spawn points
    public float spawnInterval = 3f;    // Interval between target spawns
    private float timer = 0f;           // Timer to track the spawn interval

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if the spawn interval has elapsed
        if (timer >= spawnInterval)
        {
            // Reset the timer
            timer = 0f;

            // Spawn a new target
            SpawnTarget();
        }
    }

    private void SpawnTarget()
    {
        // Randomly select a spawn point from the array
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the target prefab at the selected spawn point
        GameObject newTarget = Instantiate(targetPrefab, randomSpawnPoint.position, Quaternion.identity);

        // Optionally, you can perform additional setup or customization for the spawned target here
        // For example, you can set specific properties, attach scripts, or configure its initial state
    }

}
