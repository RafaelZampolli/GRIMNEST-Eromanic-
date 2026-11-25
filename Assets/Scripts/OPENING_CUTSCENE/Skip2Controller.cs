using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Skip2Controller : MonoBehaviour
{
    public Animator animator;
    public string sceneName;
    private bool coroutineStarted = false;
    private bool canSkip = false;
    public Text enter;

    private void Start()
    {
        enter.enabled = true;
        StartCoroutine(Piscador());
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == sceneName && !coroutineStarted)
        {
            StartCoroutine(StartSkip());
            coroutineStarted = true;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && canSkip == true)
        {
            SceneManager.LoadScene("FinalPart");
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("FinalPart");
        }
    }

    IEnumerator StartSkip()
    {
        yield return new WaitForSeconds(16.0f);
        animator.SetBool("AnimationEnded", true);
        canSkip = true;
    }

    IEnumerator Piscador()
    {
        yield return new WaitForSeconds(1.0f);
        enter.enabled = false;
        yield return new WaitForSeconds(1.0f);
        enter.enabled = true;
        StartCoroutine(Piscador());
    }

}
