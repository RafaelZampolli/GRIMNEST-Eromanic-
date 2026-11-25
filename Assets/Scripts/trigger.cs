using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    public static Trigger Instance { get; private set; } // Singleton instance
    public GameObject targetObject; // Reference to the object you want to track
    public Vector3 targetPosition = new Vector3(23, 6, 0); // The position to check against
    public float range = 2.0f; // The size of the bounding box around the target position
    private Animator animator;
    public Transform cameraTransform; // Referência à Transform da câmera
    public Vector2 offset = Vector2.zero; // Offset opcional para ajustar a posição

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

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (targetObject != null)
        {
            // Check if the target object is within the range of the target position
            if (Vector3.Distance(targetObject.transform.position, targetPosition) <= range)
            {
                animator.SetBool("AnimTrigger", true);
                StartCoroutine("Ending");
            }
        }
        
        transform.position = new Vector3(cameraTransform.position.x + offset.x,
                                         cameraTransform.position.y + offset.y,
                                         transform.position.z); // Mantém o eixo Z do objeto
    }
    IEnumerator Ending()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("WinScreen");
    }
}
