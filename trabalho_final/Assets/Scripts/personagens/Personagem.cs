using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personagem : MonoBehaviour
{
    
    private float velocidadeDescolamento = 2f;
    private int duracaoBateria = 5;

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
        var deslocX = Input.GetAxisRaw("Horizontal");
        var addX = deslocX * velocidadeDescolamento * Time.deltaTime;
        var novoX = transform.position.x + addX;
        
        var deslocY = Input.GetAxisRaw("Vertical");
        var addY = deslocY * velocidadeDescolamento * Time.deltaTime;
        var novoY = transform.position.y + addY;

        if (novoX > 9f || novoX < -9f)
        {
            novoX = transform.position.x;
        }
        
        if (novoY > 4.7f || novoY < -4.7f)
        {
            novoY = transform.position.y;
        }

        transform.position = new Vector3(novoX, novoY, transform.position.z);

        var rotatacaoZ = rotacao(transform.rotation.z, deslocX, deslocY);

        if (transform.rotation.z != rotatacaoZ)
        {
            transform.eulerAngles = new Vector3(0, 0, rotatacaoZ);
        }

        ///////////////////////////////////////////// Fim movimentação
        
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


    float rotacao(float rotatacaoZ, float deslocX, float deslocY)
    {
        if (deslocX == 1)
        {
            rotatacaoZ = 270;
        } else if (deslocX == -1)
        {
            rotatacaoZ = 90;
        }
        
        if (deslocY == 1)
        {
            if (deslocX == 1)
            {
                rotatacaoZ = 315;
            } else if (deslocX == -1)
            {
                rotatacaoZ = 45;
            }
            else
            {
                rotatacaoZ = 0;
            }
            
        } else if (deslocY == -1)
        {
            if (deslocX == 1)
            {
                rotatacaoZ = 255;
            } else if (deslocX == -1)
            {
                rotatacaoZ = 135;
            }
            else
            {
                rotatacaoZ = 180;
            }
        }

        return rotatacaoZ;
    }
    
}
