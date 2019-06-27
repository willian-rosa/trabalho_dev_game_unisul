using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interruptor : MonoBehaviour
{

    public GameObject[] lampadas;
    
    private bool dentro;
    private bool missaoCompletada;
    private Camera viewCamera;
    private float tempoMissaoCompletada;
    public GameObject txtInterruptor;

    public Text labelMissaoCompleta;
    public bool exibirCenaVitoria;
    
    
    // Start is called before the first frame update
    void Start()
    {
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (dentro && !missaoCompletada) {
            txtInterruptor.SetActive(true);
        }

        if (dentro && Input.GetKeyDown(KeyCode.F))
        {

            foreach (var lampada in lampadas)
            {
                lampada.SetActive(true);
            }
            
            Controle.movimentarCamerera = false;
            tempoMissaoCompletada = Time.time; 
            missaoCompletada = true;
            txtInterruptor.SetActive(false);
            labelMissaoCompleta.text = "Missão Completa";
            Personagem.permiteGameOver = false;

        }

        float segundosMC = Time.time - tempoMissaoCompletada;
        
        if (missaoCompletada && 
            segundosMC < 3f && 
            viewCamera.orthographicSize < 8f
        ){
            // afastando tela
            viewCamera.orthographicSize = viewCamera.orthographicSize + .02f;
        } else if (missaoCompletada && segundosMC > 4f)
        {
            if (exibirCenaVitoria)
            {
                SceneManager.LoadScene("gameWin");
            }
            else
            {
                SceneManager.LoadScene("fase2");
            }
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
