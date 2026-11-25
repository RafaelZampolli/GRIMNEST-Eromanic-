using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnergencyFollowCamera : MonoBehaviour
{
    public static EnergencyFollowCamera Instance { get; private set; }

    public Transform cameraTransform; // Referência para o Transform da câmera
    public Transform cameraTransformBack; // Referência para o Transform da câmera quando a BackScene é ativada.
    public Vector2 offset = Vector2.zero; // Offset opcional para ajustar a posição

    void Awake()
    {
        // Verifica se já existe uma instância
        if (Instance == null)
        {
            Instance = this;
            string currentScene = SceneManager.GetActiveScene().name;

            // Verifica se a cena atual é "FrontScene" ou "BackScene"
            if (currentScene != "FrontScene" && currentScene != "BackScene")
            {
                Destroy(gameObject); // Destrói se não está nas cenas específicas
            }
            else
            {
                DontDestroyOnLoad(gameObject); // Persiste apenas nas cenas específicas
            }
        }
        else
        {
            Destroy(gameObject); // Destrói se já existe uma instância
        }
    }

    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        transform.position = new Vector3(cameraTransform.position.x + offset.x, cameraTransform.position.y + offset.y, transform.position.z);



        if (currentScene == "BackScene")
        {

            transform.position = new Vector3(cameraTransformBack.position.x + offset.x, cameraTransformBack.position.y + offset.y, cameraTransformBack.position.z);
        }
    }
}
