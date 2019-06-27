using UnityEngine;

public class NovaBateria : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Find("playerBateria").GetComponent<AudioSource>().Play();
        Personagem.quantidadeBateriasExtras++;
        
        Destroy(gameObject);
        
    }
}
