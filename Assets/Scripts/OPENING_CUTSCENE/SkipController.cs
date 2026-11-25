using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SkipController : MonoBehaviour
{
    public Animator animator;
    public string sceneName;
    private bool coroutineStarted = false;
    private bool canSkip = false;

    public Text esc;

    private void Start()
    { 
        esc.enabled = true;
        StartCoroutine(Piscador());
    }


    void Update()
    {
        if(SceneManager.GetActiveScene().name == sceneName && !coroutineStarted)
        {
            StartCoroutine(StartSkip());
            coroutineStarted = true;    
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && canSkip == true)
        {
            SceneManager.LoadScene("PartTwo");
        }
        
     
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("PartTwo");
        }
    }

    IEnumerator StartSkip()
    {
        yield return new WaitForSeconds(17.0f);
        animator.SetBool("AnimationEnded", true);
        canSkip = true;
    }

    IEnumerator Piscador()
    {
        yield return new WaitForSeconds(1.0f);
        esc.enabled = false;
        yield return new WaitForSeconds(1.0f);
        esc.enabled = true;
        StartCoroutine(Piscador());
    }


}
