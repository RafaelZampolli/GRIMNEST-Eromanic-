using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sumindo : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obj.GetComponent<SpriteRenderer>().enabled = false;
        obj.GetComponent<SpriteRenderer>().enabled = true;
    }
}
