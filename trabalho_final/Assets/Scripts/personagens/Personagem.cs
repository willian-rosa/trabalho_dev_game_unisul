using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personagem : MonoBehaviour
{
    private int duracaoBateria = 10;

    private int cargaBateria;
    private float tempoUsoLanterna;
    private float tempoLanternaPiscando;
    private bool usandoLanterna;

    public Text vlBateria;
    public GameObject objLanterna;

    public Sprite[] spritesBateria;
    public Image bateria;
    
    

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
        if (usandoLanterna) { gerenciarConsumoBateria(); }

    }

    void gerenciarConsumoBateria()
    {
        if (Time.time - tempoUsoLanterna >= 1f)
        {
            tempoUsoLanterna = Time.time;
            cargaBateria-= 1;
            bateria.sprite = spritesBateria[cargaBateria];
            //Bateria.text = cargaBateria + "s";
        } else if (cargaBateria <= 1f && Time.time -tempoLanternaPiscando >= 0.15f)
        {
            tempoLanternaPiscando = Time.time;
            objLanterna.SetActive( ! objLanterna.activeSelf );
        }

        if (cargaBateria <= 0)
        {
            objLanterna.SetActive(false);
            usandoLanterna = false;
        }
    }

    void acenderLanterna()
    {
        objLanterna.SetActive(true);
        tempoUsoLanterna = Time.time;
        usandoLanterna = true;
        cargaBateria = 5;
        tempoLanternaPiscando = 1;
    }

}
