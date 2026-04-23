using UnityEngine;

// Este script va en el PREFAB de la bala
public class Bala : MonoBehaviour
{
    public int daño = 1;                   // Lo asigna EnemyShooter automáticamente
    public float tiempoVida = 4f;          // La bala se destruye sola después de X segundos

    void Start()
    {
        // Destruir la bala si no golpea nada
        Destroy(gameObject, tiempoVida);
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        // Si toca al jugador, le quita vida
        if (otro.CompareTag("Player"))
        {
            PlayerHealth vida = otro.GetComponent<PlayerHealth>();
            if (vida != null)
            {
                vida.TakeDamage(daño); // Usa exactamente tu método TakeDamage
            }
            Destroy(gameObject); // Destruye la bala al impactar
        }

        // Si toca el suelo u otro obstáculo (que no sea el propio enemigo), se destruye
        if (!otro.CompareTag("Enemy") && !otro.isTrigger)
        {
            Destroy(gameObject);
        }
    }
}
