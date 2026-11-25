using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Energy : MonoBehaviour
{
    static public int BatteryLevel = 4; // Battery level
    [SerializeField] float batteryDepletionTime = 15f; // Time interval for battery depletion
    private bool corroutinestarted = false;
    public static Energy Instance { get; private set; }
    public Animator fadeout;

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
        StartCoroutine(DecreaseBatteryLevelOverTime());
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the "Battery" tag
        if (collision.gameObject.CompareTag("Battery"))
        {
            if (BatteryLevel < 4)
            {
                BatteryLevel++; // Increase battery level
                Destroy(collision.gameObject); // Remove the battery
            }

            // Update the battery level on the text UI

        }
    }


    IEnumerator DecreaseBatteryLevelOverTime()
    {
        while (BatteryLevel > 0)
        {
            yield return new WaitForSeconds(batteryDepletionTime);
            BatteryLevel--; // Decrease battery level every specified time
        }
    }

    private void Update()
    {
        if (BatteryLevel == 0 && !corroutinestarted)
        {
            StartCoroutine("soal");
        }
    }

    IEnumerator soal()
    {
        yield return new WaitForSeconds(1.5f);
        fadeout.SetTrigger("Morreu");
        SceneManager.LoadScene("NoEnergyDeath");
    }
}

