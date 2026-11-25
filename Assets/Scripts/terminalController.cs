using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class terminalController : MonoBehaviour
{
    [SerializeField] private Button ventButton;
    [SerializeField] private Button motButton;


    public Canvas[] terminalCanvas;

    int idCanvas = 0;

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
