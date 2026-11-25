using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempManager : MonoBehaviour
{
    public static TempManager Instance { get; private set; }


    // Propriedade Quente
    public bool Quente { get; private set; } = false; // Alterado para private set para melhor encapsulamento

    public void SetQuente(bool value)
    {
        Quente = value;
    }

    public Animator animator;
    public Animator emergency;


    // Durações
    public float timer = 0f;
    public float quenteDuration = 22f; // Tempo que Quente deve durar
    public float checkInterval = 25f;   // Tempo de verificação

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

    void Start()
    {
        InvokeRepeating("CheckTemperature", 0f, checkInterval);
    }

    void Update()
    {
        if (!Quente)
        {
            // Continua contando até 25 segundos
            timer += Time.deltaTime;

            if (timer >= checkInterval) // Quando chega a 25 segundos
            {
                timer = 0f; // Reinicia o timer
            }

            return; // Não faz nada se Quente for false
        }

        // Se Quente é true, verifica o tempo de quenteDuration
        if (quenteDuration > 0f)
        {
            quenteDuration -= Time.deltaTime; // Decrementa quenteDuration

            if (quenteDuration <= 0f) // Se quenteDuration chega a 0
            {
                SceneManager.LoadScene("TempDeath");
            }
        }

        animator.SetBool("IsQuente", Quente);
        emergency.SetBool("Emergency", Quente);

        
    }

    void CheckTemperature()
    {
        // 25% de chance de ativar a variável 'quente'
        if (Random.Range(0f, 1f) <= 0.25f)
        {
            if (!Quente) // Apenas ativa Quente se estava falso
            {
                Quente = true;
                quenteDuration = 22f; // Reinicia quenteDuration
                Debug.Log("A variável Quente foi ativada.");
            }
        }
        else
        {
            // Mantém Quente como está, mas aqui podemos adicionar uma lógica opcional
            // que poderia permitir desativar Quente após um certo tempo ou condições.
        }
    }
}