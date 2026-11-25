using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToggle : MonoBehaviour

{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        PlayManualHide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleEscapePress();
        }
    }

    private void HandleEscapePress()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ManualHide"))
        {
            PlayManualUp();
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("ManualShow"))
        {
            PlayManualDown();
        }
    }

    private void PlayManualHide()
    {
        animator.Play("ManualHide");
      
    }

    private void PlayManualUp()
    {
        animator.Play("ManualUp");
        StartCoroutine(WaitAndPlay("ManualShow"));
    }

    private void PlayManualDown()
    {
        animator.Play("ManualDown");
        StartCoroutine(WaitAndPlay("ManualHide"));
    }

    private System.Collections.IEnumerator WaitAndPlay(string animationName)
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.Play(animationName);
    }
}
