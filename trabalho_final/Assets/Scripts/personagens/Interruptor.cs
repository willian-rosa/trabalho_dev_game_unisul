using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interruptor : MonoBehaviour
{

    public GameObject[] lampadas;
    
    private bool dentro;
    private bool missaoCompletada;
    private Camera viewCamera;
    private float tempoMissaoCompletada;

    public Text labelMissaoCompleta;
    
    
    // Start is called before the first frame update
    void Start()
    {
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (dentro && Input.GetButtonDown("Fire1"))
        {
            foreach (var lampada in lampadas)
            {
                lampada.SetActive(true);
            }
            
            Controle.movimentarCamerera = false;
            tempoMissaoCompletada = Time.time; 
            missaoCompletada = true;

            labelMissaoCompleta.text = "Missão Completa";

        }

        if (missaoCompletada && 
            (Time.time - tempoMissaoCompletada) < 3f && 
            viewCamera.orthographicSize < 8f
        ){
            viewCamera.orthographicSize = viewCamera.orthographicSize + .02f;
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
