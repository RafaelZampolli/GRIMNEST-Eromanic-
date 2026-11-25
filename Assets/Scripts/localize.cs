using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localize : MonoBehaviour
{
    [SerializeField] GameObject serbis;
    [SerializeField] GameObject objs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 local = serbis.transform.position;
        objs.transform.position = local;
    }
}
