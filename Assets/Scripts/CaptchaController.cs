using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class CaptchaController : MonoBehaviour
{
    // Variável que verifica se o nome da cena está correto, para sortear qual captcha começar.
    public string sceneName;
    // Variável necessária para fazer as corrotinas colocadas no update não rodarem eternamente e acabarem com a Unity.
    private bool coroutineStarted = false;
    // Verifica se a resposta escrita pelo player é a correta e a mesma do captcha.
    public Text respostaCaptcha;
    // Variável que indica sobre qual animação o código se trata.
    public Animator randomizerAnimation;
    // Variável apenas para falar qual camada do Animator será utilizada
    public int animationLayer = 0;
    // Variável que verifica se a animação tem o mesmo nome que o descrito.
    public string animationName;
    // Define "currentFrame" como uma variável de classe -- fora de uma função
    private int currentFrame;
    // Código que sorteia qual dos 3 Captchas vai aparecer.
    private int captchaRandomizer;

    private bool captchaFinished;

    public Text captchaResolvido;


    // A função start, logo que abre a cena sorteia um número, e então executa a função que começa a animação em um
    // frame específico.
    private void Start()
    {
        captchaFinished = false;
        captchaResolvido.enabled = false;
        
        captchaRandomizer = Random.Range(1, 4);
        if (captchaRandomizer == 1)
        {
            StartAnimationAtFrame(0);
        }
        else if(captchaRandomizer == 2)
        {
            StartAnimationAtFrame(720);
        }
        else if (captchaRandomizer == 3)
        {
            StartAnimationAtFrame(1440);
        }
    }

    void Update()
    {
        GetFrame();

        if (!coroutineStarted)
        {
            if ((captchaRandomizer == 1 || currentFrame >= 0 && currentFrame < 719) && respostaCaptcha.text == "7AoMT")
            {
                StartCoroutine(BackToMenu());
            }
            else if ((captchaRandomizer == 2 || currentFrame >= 720 && currentFrame < 1439) && respostaCaptcha.text == "u9PLj3H")
            {
                StartCoroutine(BackToMenu());
            }
            else if ((captchaRandomizer == 3 || currentFrame >= 1440 && currentFrame < 2161) && respostaCaptcha.text == "m3MphI")
            {
                StartCoroutine(BackToMenu());
            }
        }

        // Para mostrar o texto que concluiu o captcha.
        if (captchaFinished == true)
        {
            captchaResolvido.enabled = true;
        }
    }

    // Corrotina que volta para o menu.
    IEnumerator BackToMenu()
    {
        coroutineStarted = true;
        captchaFinished = true;
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("TerminalMenu");
    }

    // Função que inicia a animação a partir de um frame específico.
    void StartAnimationAtFrame(int startFrame)
    {
        // Verifica se a animação atual tem o nome correto.
        if (randomizerAnimation.GetCurrentAnimatorStateInfo(animationLayer).IsName(animationName))
        {
            // Obtém o primeiro clipe de animação associado ao Animator.
            AnimationClip clip = randomizerAnimation.runtimeAnimatorController.animationClips[0];

            // Calcula o tempo normalizado com base no frame desejado e na duração total da animação.
            float normalizedTime = (float)startFrame / (clip.length * clip.frameRate);

            // Inicia a animação no ponto especificado pelo tempo normalizado.
            randomizerAnimation.Play(animationName, animationLayer, normalizedTime);
        }
    }

    void GetFrame()
    {
        // 1. Cria uma variável chamada "stateInfo", que armazena informações sobre o estado atual da animação.
        
        // 2. Seguindo o código, "randomizerAnimation" é correspondente à variável do Animator.
        
        // 3. "GetCurrentAnimatorStateInfo(animationLayer)" obtém as informações do estado atual da animação que está rodando na
        //     camada informada pela variável animationLayer.
        AnimatorStateInfo stateInfo = randomizerAnimation.GetCurrentAnimatorStateInfo(animationLayer);

        // 1. Essa condicional apenas verifica se a animação atual tem o mesmo nome que a variável "animationName"
        //    "IsName(animationName)" returna true se tiver o nome específicado.
        if (stateInfo.IsName(animationName))
        {
            float animationDuration = stateInfo.length;
            // Cria uma variável chamada "animationDuration" que armazena a duração total da animação em segundos.

            float currentTime = stateInfo.normalizedTime % 1 * animationDuration;
            // 1. Cria uma variável chamada "currentTime" que calcula o tempo atual da animação em segundos.
            // 2. "stateInfo.normalizedTime" corresponde ao tempo normalizado, que basicamente é um valor entre 0 e 1
            //    onde 0 representa o início da animação, e 1 representa o final.
            // 3. %1 garante que o valor fique sempre entre 0 e 1, no caso de um loop na animação.
            // 4. Multiplicando tudo isso por "animationDuration"

            AnimationClip animationClip = randomizerAnimation.runtimeAnimatorController.animationClips[0];
            // 1. Pega a primeira animação da lista de animações do animator.
            // 2. "randomizerAnimation.runtimeAnimatorController" acessa o controlador de animação do objeto.
            //    O controlador define quais animações estão diponíveis.
            // 3. "animationClips[0] seleciona a primeira animação disponível."

            int fps = Mathf.RoundToInt(animationClip.frameRate);
            // 1. Essa linha cria uma variável chamada "fps" e arredonda a taxa de quadros da animação para um int.
            // 2. "animationClip.frameRate" fornece a quantidade de frame per rate que a animação usa.
            // 3. "MathF.RoundToInt" arredonda o valor para um int mais próximo.

            currentFrame = Mathf.FloorToInt(currentTime * fps);
            // 1. Essa linha calcula o quadro atual da animação e armazena o valor na variável "currentFrame"
            // 2. Ele multiplica o tempo atual - "currentTime" -- pela taxa de quadros por segundo -- "fps"
            // 3. "Mathf.FloorToInt" arredonda o valor para baixo, garantindo que seja um número inteiro.
        }
    }
}



