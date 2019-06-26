using UnityEngine;
using System.Collections;

public class Controle : MonoBehaviour {

    private Camera viewCamera;
    private float velocidadeDescolamento = 2.0f;
    public int velocidadeRotacao = 40;

    void Start () {
        viewCamera = Camera.main;
    }

    void Update () {
        var deslocX = Input.GetAxisRaw("Horizontal");
        var addX = deslocX * velocidadeDescolamento * Time.deltaTime;
        var novoX = transform.position.x + addX;
        
        var deslocY = Input.GetAxisRaw("Vertical");
        var addY = deslocY * velocidadeDescolamento * Time.deltaTime;
        var novoY = transform.position.y + addY;
		
		
        transform.position = new Vector3(novoX, novoY, transform.position.z);
        viewCamera.transform.position = new Vector3(novoX, novoY, viewCamera.transform.position.z);
		
		
//		var rotatacaoZ = rotacao(transform.rotation.z, deslocX, deslocY);
//
//        if (transform.rotation.z != rotatacaoZ)
//        {
//            transform.eulerAngles = new Vector3(0, 0, rotatacaoZ);
//        }
		
		
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * velocidadeRotacao;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
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