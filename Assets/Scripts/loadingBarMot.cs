using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingBarMot : MonoBehaviour
{
    public GameObject canvasName;
    private bool coroutineStarted = false;
    
    
    void Update()
    {
        if (canvasName.activeSelf && !coroutineStarted)
        {
            StartCoroutine(LoadingBar());
            coroutineStarted = true;
        }

        IEnumerator LoadingBar()
        {
            yield return new WaitForSeconds(10.0f);
            SceneManager.LoadScene("TerminalMenu");
        }
    }
}
