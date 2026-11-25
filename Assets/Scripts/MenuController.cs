using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Text pressEnter;

    private void Start()
    {
        pressEnter.enabled = true;
        StartCoroutine(Piscante());
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("PartOne");
        }
            
    }

    IEnumerator Piscante()
    {
        pressEnter.enabled = false;
        yield return new WaitForSeconds(1.0f);
        pressEnter.enabled = true;
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Piscante());
    }
}
