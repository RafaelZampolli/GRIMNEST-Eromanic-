using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TempDeathController : MonoBehaviour
{
    public Text desc;
    public Text hint;
    public Text enter;
    // Reconhecer 

    public SpriteRenderer sr;
    private float duration = 4f;

    public float targetOpacity = 1.0f;
    public float targetOpacityHint;
    public float fadeDuration = 2.0f;

    public string sceneName;
    private bool coroutineStarted;
    private bool canBlink = false;

    private void Awake()
    {
        if (sr == null)
        {
            sr = GetComponent<SpriteRenderer>();
        }
    }


    void Start()
    {
        desc.enabled = false;
        hint.enabled = false;
        enter.enabled = false;

        Color descColor = desc.color;
        descColor.a = 0f;
        desc.color = descColor;

        Color hintColor = hint.color;
        hintColor.a = 0f;
        hint.color = hintColor;






    }


    void Update()
    {
        if (SceneManager.GetActiveScene().name == sceneName && !coroutineStarted)
        {
            StartCoroutine(FadeInBackground());
            StartCoroutine(FadeInTexts());
            coroutineStarted = true;
        }

        if (canBlink == true && Input.GetKeyDown("return"))
        {
            SceneManager.LoadScene("MenuScene");
        }


    }

    IEnumerator FadeInBackground()
    {
        float time = 0.0f;

        while (time < duration)
        {
            yield return null;

            float alpha = Mathf.Lerp(0.0f, 1.0f, time / duration);

            Color newColor = sr.color;
            newColor.a = alpha;
            sr.color = newColor;

            time += Time.deltaTime;
        }

    }

    IEnumerator FadeInTexts()
    {
        yield return new WaitForSeconds(5f);

        yield return StartCoroutine(FadeInText(desc));
        yield return StartCoroutine(FadeInHint());
        canBlink = true;
        StartCoroutine(PressEnter());
    }

    IEnumerator FadeInText(Text text)
    {
        float time = 0;
        Color textColor = text.color;
        float startOpacity = textColor.a; // Faz começar com a opacidade atual


        text.enabled = true;


        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startOpacity, targetOpacity, time / fadeDuration);
            textColor.a = alpha;
            text.color = textColor;

            yield return null; // Espera até o próximo frame
        }

        textColor.a = targetOpacity;
        text.color = textColor;
    }

    IEnumerator FadeInHint()
    {
        float time = 0;
        Color textColor = hint.color;
        float startOpacity = textColor.a; // Faz começar com a opacidade atual
        

        hint.enabled = true;


        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startOpacity, targetOpacityHint, time / fadeDuration);
            textColor.a = alpha;
            hint.color = textColor;

            yield return null; // Espera até o próximo frame
        }

        textColor.a = targetOpacityHint;
        hint.color = textColor;
    }

    IEnumerator PressEnter()
    {
        enter.enabled = true;
        yield return new WaitForSeconds(1.0f);
        enter.enabled = false;
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(PressEnter());
    }

}
