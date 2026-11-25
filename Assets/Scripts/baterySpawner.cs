using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baterySpawner : MonoBehaviour
{

    public GameObject ply;
    public GameObject batteryPrefab; // Reference to the battery prefab
    public int batteryCount = 4; // Number of batteries to spawn
    public float areaWidth = 10f; // Width of the spawn area
    public float areaHeight = 10f; // Height of the spawn area

    private List<GameObject> batteries = new List<GameObject>();

    void Start()
    {
        // Spawn initial batteries
        SpawnBatteries();

        // Start the coroutine to respawn batteries periodically
        StartCoroutine(SpawnDisRoutine());
    }

    IEnumerator SpawnDisRoutine()
    {
        while (true)
        {
            // Remove old batteries before spawning new ones
            foreach (GameObject battery in batteries)
            {
                Destroy(battery);
            }
            batteries.Clear();

            // Spawn new batteries
            SpawnBatteries();

            // Wait for 30 seconds before spawning again
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnBatteries()
    {
        for (int i = 0; i < batteryCount; i++)
        {
            // Generate a random position within the defined area
            Vector2 spawnPosition = new Vector2(
                Random.Range(-areaWidth / 2, areaWidth / 2),
                Random.Range(-areaHeight / 2, areaHeight / 2)
            );

            // Spawn battery at the random position
            GameObject newBattery = Instantiate(batteryPrefab, spawnPosition, Quaternion.identity);

            // Add battery to the list
            batteries.Add(newBattery);
        }
    }

    public void RemoveBattery(GameObject battery)
    {
        // Remove battery from the list
        batteries.Remove(battery);

        // Destroy the battery object
        Destroy(battery);
    }
}
