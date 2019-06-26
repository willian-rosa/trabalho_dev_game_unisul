using UnityEngine;

public class NovaBateria : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        Personagem.quantidadeBateriasExtras++;
        
        Destroy(gameObject);
        
    }
}
