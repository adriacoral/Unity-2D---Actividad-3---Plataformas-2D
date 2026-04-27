using UnityEngine;

// Ponlo en el jugador
public class CaidaVacio : MonoBehaviour
{
    public float limiteY = -10f; // Si el jugador baja de este punto, respawnea

    private PlayerHealth vida;

    void Start()
    {
        vida = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (transform.position.y < limiteY)
        {
            vida.TakeDamage(vida.maxHealth); // Quita toda la vida → llama a Respawn
        }
    }
}
