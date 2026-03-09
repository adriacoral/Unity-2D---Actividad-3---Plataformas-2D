using UnityEngine;

// 📦 SCRIPT 2 (FIX): Hace que el jugador se mueva junto a la plataforma
// ✅ FIX: Ya NO usamos SetParent (rompía el Rigidbody2D del jugador)
//         Ahora movemos al jugador manualmente con el delta de la plataforma
// ⚠️ Requiere que el jugador tenga el tag "Player"

public class PlatformCarrier : MonoBehaviour
{
    private Transform jugador;          // jugador encima de la plataforma (o null)
    private Vector3 posicionAnterior;   // posición de la plataforma el frame anterior

    void Start()
    {
        posicionAnterior = transform.position;
    }

    void LateUpdate()
    {
        // Si hay jugador encima → lo arrastramos con la plataforma
        if (jugador != null)
        {
            Vector3 delta = transform.position - posicionAnterior;
            jugador.position += delta;
        }

        posicionAnterior = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Player") && JugadorEncima(colision))
        {
            jugador = colision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Player"))
        {
            jugador = null;
        }
    }

    // Comprueba que el jugador viene desde arriba
    bool JugadorEncima(Collision2D colision)
    {
        foreach (ContactPoint2D contacto in colision.contacts)
        {
            if (contacto.normal.y > 0.5f)
                return true;
        }
        return false;
    }
}
