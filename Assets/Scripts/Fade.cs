using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Fade", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(1);

        if(collision.gameObject.tag == "radar")
        {
            StartCoroutine(Fading(1.0f));
        }
    }

    IEnumerator Fading(float t)
    {
        animator.SetBool("Fade", false);
        yield return new WaitForSeconds(t);
        animator.SetBool("Fade", true);
    }
}
