using UnityEngine;

// 📦 SCRIPT 2: Arrastra al jugador con la plataforma
// ✅ Usa OnCollisionStay2D para detectar contacto continuo
// ✅ Mueve al jugador con MovePosition (respeta la física)

public class PlatformCarrier : MonoBehaviour
{
    private Rigidbody2D rbJugador;
    private bool jugadorEncima = false;
    private Vector2 posicionAnterior;

    void Start()
    {
        posicionAnterior = transform.position;
    }

    // Se llama cada frame que el jugador está en contacto
    void OnCollisionStay2D(Collision2D colision)
    {
        if (!colision.gameObject.CompareTag("Player")) return;

        foreach (ContactPoint2D contacto in colision.contacts)
        {
            if (contacto.normal.y > 0.5f) // contacto desde arriba
            {
                jugadorEncima = true;
                rbJugador = colision.gameObject.GetComponent<Rigidbody2D>();
                return;
            }
        }
        // Si ningún contacto es desde arriba → no está encima
        jugadorEncima = false;
    }

    void OnCollisionExit2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Player"))
        {
            jugadorEncima = false;
            rbJugador = null;
        }
    }

    void FixedUpdate()
    {
        Vector2 delta = rb().position - posicionAnterior;

        if (jugadorEncima && rbJugador != null)
        {
            // ✅ MovePosition en vez de transform → no rompe la física del jugador
            rbJugador.MovePosition(rbJugador.position + delta);
        }

        posicionAnterior = rb().position;
    }

    // Acceso rápido al Rigidbody2D de la plataforma
    Rigidbody2D rb() => GetComponent<Rigidbody2D>();
}
