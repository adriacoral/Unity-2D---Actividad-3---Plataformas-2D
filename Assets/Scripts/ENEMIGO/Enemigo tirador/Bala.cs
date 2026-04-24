using UnityEngine;

// Este script va en el PREFAB de la bala
public class Bala : MonoBehaviour
{
    public int daño = 1;
    public float tiempoVida = 4f;

    private bool yaGolpeo = false;         // Evita que dañe más de una vez
    private GameObject quienDisparo;       // Referencia al enemigo que la disparó

    // EnemyShooter llama a esto justo después de crear la bala
    public void Inicializar(GameObject emisor)
    {
        quienDisparo = emisor;

        // Ignora físicamente la colisión entre la bala y el enemigo que la disparó
        Collider2D colBala = GetComponent<Collider2D>();
        Collider2D colEnemigo = emisor.GetComponent<Collider2D>();
        if (colBala != null && colEnemigo != null)
        {
            Physics2D.IgnoreCollision(colBala, colEnemigo);
        }

        Destroy(gameObject, tiempoVida);
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (yaGolpeo) return;              // Si ya golpeó, ignora todo lo demás

        // Ignora triggers (como el CircleCollisionDetector del jugador)
        if (otro.isTrigger) return;

        // Ignora al enemigo que disparó
        if (quienDisparo != null && otro.gameObject == quienDisparo) return;

        // Si toca al jugador, le hace daño
        if (otro.CompareTag("Player"))
        {
            yaGolpeo = true;
            PlayerHealth vida = otro.GetComponent<PlayerHealth>();
            if (vida != null)
            {
                vida.TakeDamage(daño);
                Debug.Log("¡Bala golpeó al jugador! Daño: " + daño);
            }
        }

        // En cualquier impacto válido, se destruye
        yaGolpeo = true;
        Destroy(gameObject);
    }
}
