using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTelaBateria : MonoBehaviour
{
    public Animator animator;
    int currentBatteryLevel;
    
    void Start()
    {
  
    }

    void Update()
    {
        currentBatteryLevel = Energy.BatteryLevel;

        if (currentBatteryLevel == 1)
        {
            animator.Play("1BAT");
        }

        if (currentBatteryLevel == 2)
        {
            animator.Play("2BAT");
        }

        if (currentBatteryLevel == 3)
        {
            animator.Play("3BAT");
        }

        if (currentBatteryLevel == 4)
        {
            animator.Play("4BAT");
        }
    }
}
