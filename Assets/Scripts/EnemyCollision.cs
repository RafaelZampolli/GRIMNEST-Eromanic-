using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private GameObject ply;  // Reference to the player object.
    public float areaWidth = 5f;   // Width of the area around the player where the enemy can spawn.
    public float areaHeight = 5f;  // Height of the area around the player where the enemy can spawn.

    // This function is called when the script starts.
    private void Start()
    {
        // Find the player object by tag.
        ply = GameObject.FindWithTag("Player");
    }

    // Detect collision with the wall (solid objects, not triggers).
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the enemy collided with an object tagged as "Wall".
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Move the enemy to a new random location around the player.
            MoveToNewLocation();
        }
    }

    // Function to move the enemy to a new random location around the player.
    private void MoveToNewLocation()
    {
        // Calculate a random spawn position around the player.
        Vector2 spawnPosition = new Vector2(
            Random.Range((ply.transform.position.x * -1.3f) - areaWidth, (ply.transform.position.x * 1.3f) + areaWidth),
            Random.Range((ply.transform.position.y * -1.3f) - areaHeight, (ply.transform.position.y * 1.3f) + areaHeight)
        );

        // Set the enemy's position to the new spawn position.
        transform.position = spawnPosition;
    }
}