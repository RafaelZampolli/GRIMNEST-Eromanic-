using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target; // Reference to the target

    public static CameraFollow Instance { get; private set; }

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



    void Update()
    {
        if (target != null) // Ensure target is assigned
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    }
}

