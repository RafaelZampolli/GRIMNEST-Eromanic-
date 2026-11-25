using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public static rotation Instance { get; private set; } // Singleton instance
    public GameObject jobje; // Object to rotate
    public GameObject playsd; // Reference object
    public float spinningSpeed = 60f; // Rotation speed in degrees per second



    // Update is called once per frame
    void Update()
    {
        // Rotate the object around the z-axis
        jobje.transform.Rotate(0f, 0f, spinningSpeed * Time.deltaTime);

        // Set the position of jobje to the position of playsd
        if (playsd != null)
        {
            Vector2 vector2 = playsd.transform.position;
            jobje.transform.position = vector2;
        }
    }
}