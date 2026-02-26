using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Cuánta vida quita al tocar
    public int damageAmount = 1;

    // Se llama automáticamente cuando dos colliders se tocan
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si lo que tocamos tiene el script PlayerHealth
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
        {
            // Llamar al método de daño del jugador
            player.TakeDamage(damageAmount);
        }
    }
}