using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Vida máxima del jugador
    public int maxHealth = 3;

    // Vida actual (empieza igual que la máxima)
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Este método se llama desde fuera para restar vida
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Vida restante: " + currentHealth);

        // Si la vida llega a 0 o menos, hacer respawn
        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Buscamos el punto de respawn en la escena
        PlayerRespawn respawnPoint = FindFirstObjectByType<PlayerRespawn>();

        if (respawnPoint != null)
        {
            // Mover al jugador al punto de respawn
            transform.position = respawnPoint.transform.position;
        }

        // Restaurar vida completa
        currentHealth = maxHealth;
        Debug.Log("¡Respawn! Vida restaurada.");
    }
}