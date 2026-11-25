using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public Text desc;
    public Text end;
 

    public SpriteRenderer sr;
    private float duration = 4f;

    public float targetOpacityEnd;
    public float targetOpacity = 1.0f;
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
        end.enabled = false;

        Color descColor = desc.color;
        descColor.a = 0f;
        desc.color = descColor;

        Color endColor = end.color;
        endColor.a = 0f;
        end.color = endColor;






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
        yield return StartCoroutine(FadeInEnd());
        canBlink = true;
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

    IEnumerator FadeInEnd()
    {
        float time = 0;
        Color textColor = end.color;
        float startOpacity = textColor.a; // Faz começar com a opacidade atual


        end.enabled = true;


        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startOpacity, targetOpacityEnd, time / fadeDuration);
            textColor.a = alpha;
            end.color = textColor;

            yield return null; // Espera até o próximo frame
        }

        textColor.a = targetOpacityEnd;
        end.color = textColor;
    }



}

