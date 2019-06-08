using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    
    private float velocidadeDescolamento = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        float deslocX = Input.GetAxisRaw("Horizontal");
        float addX = deslocX * velocidadeDescolamento * Time.deltaTime;
        float novoX = transform.position.x + addX;
        
        float deslocY = Input.GetAxisRaw("Vertical");
        float addY = deslocY * velocidadeDescolamento * Time.deltaTime;
        float novoY = transform.position.y + addY;

        if (novoX > 9f || novoX < -9f)
        {
            novoX = transform.position.x;
        }
        
        if (novoY > 4.7f || novoY < -4.7f)
        {
            novoY = transform.position.y;
        }

        transform.position = new Vector3(novoX, novoY, transform.position.z);

        float rotatacaoZ = rotacao(transform.rotation.z, deslocX, deslocY);

        if (transform.rotation.z != rotatacaoZ)
        {
            transform.eulerAngles = new Vector3(0, 0, rotatacaoZ);
        }
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
