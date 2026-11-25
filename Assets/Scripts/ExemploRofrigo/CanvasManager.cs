using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CanvasManager : MonoBehaviour
{
    public Canvas[] uiCanvas;

    int idCanvas = 0;
    
        
    void Update()
    {
        if (Input.anyKeyDown)
        {
            uiCanvas[idCanvas].enabled = false;
            idCanvas++;
            uiCanvas[idCanvas].enabled = true;

            if (idCanvas >= uiCanvas.Length)
            {
                idCanvas = 0;
            }
        }
    }
}
