using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    
    private float velocidadeDescolamento = 6;
    
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

    }
    
}
