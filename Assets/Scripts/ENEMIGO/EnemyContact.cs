using UnityEngine;

// Ponlo en el enemigo - hace daño al jugador si lo toca
public class EnemyContact : MonoBehaviour
{
    public int daño = 1;                   // Daño por contacto
    public float cooldown = 1f;            // Segundos entre golpe y golpe
    private float timerCooldown = 0f;

    void Update()
    {
        if (timerCooldown > 0)
            timerCooldown -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GolpearJugador(col.collider);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        GolpearJugador(col.collider);
    }

    void GolpearJugador(Collider2D otro)
    {
        if (timerCooldown > 0) return;  // Espera el cooldown

        if (otro.CompareTag("Player"))
        {
            PlayerHealth vida = otro.GetComponent<PlayerHealth>();
            if (vida != null)
            {
                vida.TakeDamage(daño);
                timerCooldown = cooldown;   // Reinicia el cooldown
                Debug.Log("Enemigo golpeó al jugador!");
            }
        }
    }
}
