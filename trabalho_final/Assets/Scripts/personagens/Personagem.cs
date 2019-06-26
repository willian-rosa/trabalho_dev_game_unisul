using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Personagem : MonoBehaviour
{
    private int cargaBateria;
    private float tempoUsoLanterna;
    private float tempoLanternaPiscando;
    private bool usandoLanterna;

    public static int quantidadeBateriasExtras = 3;
    
    public Text vlBateria;
    public GameObject objLanterna;
    public GameObject[] bateriasExtras;

    public Sprite[] spritesBateria;
    public Image bateria;
    
    private float tempoLanternaApagada;
    

    // Start is called before the first frame update
    void Start()
    {
        acenderLanterna();
    } 

    // Update is called once per frame
    void Update()
    {
        
        // Acendendo lanterna
        if (Input.GetButtonDown("Jump")) { acenderLanterna();}

        if (usandoLanterna)
        {
            gerenciarConsumoBateria();
        } else if (!usandoLanterna)
        {
            gerenciarFantasma();
        }

    }

    void gerenciarConsumoBateria()
    {
        if (Time.time - tempoUsoLanterna >= 1f)
        {
            tempoUsoLanterna = Time.time;
            cargaBateria-= 1;
            
            //Trocando o sprite da bateria
            if (cargaBateria < spritesBateria.Length)
            {
                // TODO fazer com porcentagem
                bateria.sprite = spritesBateria[cargaBateria];
            }

        } else if (cargaBateria <= 1f && Time.time -tempoLanternaPiscando >= 0.15f)
        {
            tempoLanternaPiscando = Time.time;
            objLanterna.SetActive( ! objLanterna.activeSelf );
        }

        if (cargaBateria <= 0)
        {
            objLanterna.SetActive(false);
            usandoLanterna = false;
            tempoLanternaApagada = Time.time;
        }

        for (int i = 0; i < bateriasExtras.Length; i++)
        {
            if (quantidadeBateriasExtras > i)
            {
                bateriasExtras[i].SetActive(true);
            } else
            {
                bateriasExtras[i].SetActive(false);
            }
        }
        
    }

    void gerenciarFantasma()
    {
        float tempoApagada = Time.time - tempoLanternaApagada;
        
        if (tempoApagada > 5f)
        {
            SceneManager.LoadScene("gameOver");
        } else if (tempoApagada > 1.5f )
        {
            //Tocar musica
        }
    }

    void acenderLanterna()
    {
        if (quantidadeBateriasExtras > 0)
        {
            objLanterna.SetActive(true);
            tempoUsoLanterna = Time.time;
            usandoLanterna = true;
            cargaBateria = 8;
            tempoLanternaPiscando = 1;
            
            //Diminuindo uma bateria
            quantidadeBateriasExtras--;
        }
    }

}
