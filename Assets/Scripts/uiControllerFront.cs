using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiControllerFront : MonoBehaviour
{
    [SerializeField] private Button btnPlay;

    void Update()
    {
        if (Input.GetKeyDown("down"))
        {
            SceneManager.LoadScene("BackScene");
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("BackScene");
    }
}