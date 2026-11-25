using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanTerController : MonoBehaviour
{

    public Canvas[] terminalCanvas;

    int idCanvas = 0;

    [SerializeField] private Button ventButton;
    [SerializeField] private Button motButton;

    void Start()
    {
        terminalCanvas[0].enabled = true;
        terminalCanvas[1].enabled = false;
        terminalCanvas[2].enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void MotSystem()
    {
        terminalCanvas[0].enabled = false;
        terminalCanvas[1].enabled = true;
    }

    public void OxSystem()
    {
        terminalCanvas[0].enabled = false;
        terminalCanvas[2].enabled = true;
    }
}


