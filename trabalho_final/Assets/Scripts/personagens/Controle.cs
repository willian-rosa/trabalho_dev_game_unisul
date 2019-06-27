using UnityEngine;
using System.Collections;

public class Controle : MonoBehaviour
{

    public static bool movimentarCamerera;
    
    private Camera viewCamera;
    private float velocidadeDescolamento = 2.0f;

    void Start ()
    {
        movimentarCamerera = true;
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

        if (movimentarCamerera)
        {
            viewCamera.transform.position = new Vector3(novoX, novoY, viewCamera.transform.position.z);
        }

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
    }
}