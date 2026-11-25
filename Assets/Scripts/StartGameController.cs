using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameController : MonoBehaviour
{
    public string sceneName;
    private bool coroutineStarted = false;

    void Update()
    {
        if(SceneManager.GetActiveScene().name == sceneName && !coroutineStarted)
        {
            StartCoroutine(StartGame());
            coroutineStarted = true;
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("FrontScene");
    }

}
