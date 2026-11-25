
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UpdateBallPosition : MonoBehaviour
{
    public static UpdateBallPosition Instance { get; private set; } // Singleton instance
    public GameObject ball; // Reference to the ball object
    public Text positionText; // Reference to the UI Text component
    public Text texty;
    [SerializeField] float timer = 1f; // Set a default timer value

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance == null)
        {
            Instance = this;

            string currentScene = SceneManager.GetActiveScene().name;

            // Check if the current scene is not "FrontScene" or "BackScene"
            if (currentScene != "FrontScene" && currentScene != "BackScene")
            {
                Destroy(gameObject); // Destroy if not in the specific scenes
                ball.transform.position = new Vector3(8.4f, -2.82f, ball.transform.position.z);
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
        // Start the coroutine to update the text every second
        StartCoroutine(UpdatePosition());
        
    }

    IEnumerator UpdatePosition()
    {
        while (true)
        {
            if (ball != null && positionText != null && texty != null)
            {
                // Get the ball's position
                float x = ball.transform.position.x;
                float y = ball.transform.position.y;

                int a = (int)x;
                int b = (int)y;

                // Update the text with the new position
                positionText.text = "X: " + a.ToString("F2");
                texty.text = "Y: " + b.ToString("F2");
            }

            // Wait for the specified timer before updating again
            yield return new WaitForSeconds(timer);
        }
    }
}