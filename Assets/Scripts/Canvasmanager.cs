using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvasmanager : MonoBehaviour
{
    public GameObject canvasTerminal;
    public GameObject canvasCaptcha;
    public GameObject canvasResfriar;

    void Start()
    {
        // Ativar o Canvas Terminal e esconder os outros
        canvasTerminal.SetActive(true);
        canvasCaptcha.SetActive(false);
        canvasResfriar.SetActive(false);
    }

    public void OnVentButtonClicked()
    {
        // Troca de Canvas quando o botão but_vent é clicado
        canvasTerminal.SetActive(false);
        canvasCaptcha.SetActive(true);
    }

    public void OnMotButtonClicked()
    {
        // Troca de Canvas quando o botão but_mot é clicado
        canvasTerminal.SetActive(false);
        canvasResfriar.SetActive(true);
    }
}
