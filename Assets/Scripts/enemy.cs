using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    public GameObject balls; // Reference to the ball object
    public GameObject enemys; // Reference to the enemy object
    [SerializeField] float timer; // Time interval for position updates
    [SerializeField] float moveSpeed; // Speed at which the enemy moves

    void Start()
    {
        StartCoroutine(UpdatePosition());
        balls = GameObject.FindWithTag("Player");
    }

    IEnumerator UpdatePosition()
    {
        while (true)
        {
            if (balls != null && enemys != null)
            {
                // Get the ball's (player's) position
                Vector2 ballPosition = balls.transform.position;

                // Move the enemy towards the ball's position at a constant speed
                enemys.transform.position = Vector2.MoveTowards(enemys.transform.position, ballPosition, moveSpeed * Time.deltaTime);

                // Wait for the specified time before updating again
                yield return new WaitForSeconds(timer);
            }
        }
    }
}
