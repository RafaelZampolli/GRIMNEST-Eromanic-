using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSumir : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Ligee()
    {
        text.enabled = true;
    }

    IEnumerator tsext()
    {
        yield return new WaitForSeconds(15f);
        text.enabled = false;
    }
}
