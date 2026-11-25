using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    public static EnemySpawner Instance { get; private set; }
    public GameObject ply; // Reference to the player
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public Button butao;
    public float timers; // Custom timer for removing enemies
    public Text textin; // Text to display the cooldown time
    private int enemyCount = 1; // Number of enemies to spawn


    private List<GameObject> enemies = new List<GameObject>();
    private bool isCooldown = false; // Track whether the button is on cooldown

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance == null)
        {
            Instance = this;

            // Check if the current scene is not "FrontScene" or "BackScene"
            string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            if (currentScene != "FrontScene" && currentScene != "BackScene")
            {
                Destroy(gameObject); // Destroy if not in the specific scenes
            }
            else
            {
                DontDestroyOnLoad(gameObject); // Persist the object
            }
        }
        else
        {
            Destroy(gameObject); // Destroy if an instance already exists
        }
    }


    void Start()
    {
        // Start the spawn routine with a delay before the first spawn
        StartCoroutine(SpawnEnemiesRoutine());

        // Attach the button click listener
        if (butao != null)
        {
            butao.onClick.AddListener(OnButtonClick);
        }
    }

    IEnumerator SpawnEnemiesRoutine()
    {
        // Wait 12 seconds before spawning the first enemy
        yield return new WaitForSeconds(12f);

        // After the initial wait, continue spawning enemies at intervals
        while (true)
        {
            // Spawn new enemies
            SpawnEnemies();

            // Wait for 12 seconds before respawning again
            yield return new WaitForSeconds(12f); // Adjust this time as needed
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            // Generate a random position within the defined area
            Vector2 spawnPosition = new Vector2(
                Random.Range(6, 12),
                Random.Range(23, -5)
            );

            // Spawn enemy at the random position
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Add enemy to the list
            enemies.Add(newEnemy);
        }
    }

    // Removes a single enemy from the game
    public void RemoveEnemy(GameObject enemy)
    {
        if (enemies.Contains(enemy))
        {
            // Remove enemy from the list
            enemies.Remove(enemy);

            // Destroy the enemy object
            Destroy(enemy);
        }
    }

    // Remove all enemies currently in the scene
    public IEnumerator RemoveAllEnemies()
    {
        // Iterate through the list of enemies
        foreach (GameObject enemy in enemies.ToArray()) // Copy the list to avoid modifying it while iterating
        {
            if (enemy != null)
            {
                Destroy(enemy); // Destroy the enemy GameObject
            }
        }

        // Clear the enemies list
        enemies.Clear();

        // Wait for the specified timer before finishing
        yield return new WaitForSeconds(timers);
    }

    public void OnButtonClick()
    {
        if (!isCooldown)
        {
            StartCoroutine(RemoveAllEnemies());
            StartCoroutine(ButtonCooldown());
        }
    }

    IEnumerator ButtonCooldown()
    {
        // Set cooldown state and disable the button
        isCooldown = true;
        butao.interactable = false; // Disable the button

        float cooldownTime = 24f; // Cooldown duration
        while (cooldownTime > 0)
        {
            // Update the text to display the remaining cooldown time
            textin.text = cooldownTime.ToString("F1") + "s"; // Display with one decimal place

            // Wait for the next frame
            yield return null;

            // Decrease the remaining time by the time passed in this frame
            cooldownTime -= Time.deltaTime;
        }

        // Re-enable the button and clear the cooldown text
        butao.interactable = true;
        textin.text = ""; // Clear the text
        isCooldown = false;
    }
}
