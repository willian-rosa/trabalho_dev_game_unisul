using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{

    private bool dentro;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dentro)
        {
            print("esta dentro");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        dentro = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        dentro = false;
    }
}
