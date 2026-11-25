using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OxManager : MonoBehaviour
{
    public Animator animator;  // Certifique-se de arrastar o Animator certo no Inspector
    public Animator tontura;   // Certifique-se de arrastar o Animator certo no Inspector

    public static OxManager Instance { get; private set; }

    private bool Ox;

    public float timer = 0f;
    public float checkInterval = 35f;  // Certifique-se de definir este valor no Inspector

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
        Ox = false;
        InvokeRepeating("CheckOx", 0f, checkInterval); // Verifique se checkInterval > 0
    }

    void Update()
    {
        if (!Ox) // Se Ox é false
        {
            timer += Time.deltaTime; // Incrementa o timer
        }

        animator.SetBool("IsQuente", Ox);  // Certifique-se que o parâmetro "IsQuente" exista no Animator
        tontura.SetBool("OxTrue", Ox);     // Certifique-se que o parâmetro "OxTrue" exista no Animator
    }

    // Método para definir o valor de Ox
    public void SetOx(bool value)
    {
        Ox = value;
        // Adicione qualquer lógica adicional aqui se necessário
    }

    void CheckOx()
    {
        // 25% de chance de ativar a variável 'Ox'
        if (Random.Range(0f, 1f) <= 0.25f)
        {
            if (!Ox) // Apenas ativa se não estiver ativo
            {
                ActivateOx();
            }
        }
        else
        {
            if (Ox) // Apenas desativa se estava ativo
            {
                DeactivateOx();
            }
        }
    }

    private void ActivateOx()
    {
        SetOx(true);
        Debug.Log("A variável Ox foi ativada.");
    }

    private void DeactivateOx()
    {
        SetOx(false);
        timer = 0f;
        Debug.Log("A variável Ox foi desativada e o timer resetado.");
    }
}