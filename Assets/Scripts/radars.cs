using System.Collections;
using UnityEngine;

public class RadarDetection : MonoBehaviour
{
    public Animator animator;               // Assign this in the Inspector
    private bool coroutineStarted = false;  // To prevent starting the coroutine multiple times

    private void Start()
    {
        animator.SetBool("ReturnToStatic", false);
        animator.SetBool("Touched", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name); // Debug log for collision detection

        // Check if the collided object has the tag "Battery"
        if (other.CompareTag("Battery") && !coroutineStarted)
        {
            // Get the Battery's SpriteRenderer component to manage visibility
            SpriteRenderer batteryRenderer = other.GetComponent<SpriteRenderer>();
            if (batteryRenderer != null)
            {
                batteryRenderer.enabled = true; // Show the battery
                animator.SetBool("ReturnToStatic", true); // Trigger the touch animation
                StartCoroutine(ReturnToStatic(batteryRenderer)); // Pass the SpriteRenderer to the coroutine
                coroutineStarted = true; // Set the flag to true
            }
        }
    }

    IEnumerator ReturnToStatic(SpriteRenderer batteryRenderer)
    {
        yield return new WaitForSeconds(1.0f); // Wait for 1 second

        /*
        if (batteryRenderer != null)
        {
           //  batteryRenderer.enabled = false; // Hide the battery after the animation
        }

        animator.SetBool("ReturnToStatic", true); // Trigger the return animation
        coroutineStarted = false; // Reset the flag
        animator.SetBool("Touched", false);
        animator.SetBool("ReturnToStatic", false);
        */
    }
}
