using UnityEngine;

public class AtaqueCaida : MonoBehaviour
{
    [Header("Configuración")]
    public float fuerzaCaida = 20f;        // Velocidad hacia abajo al atacar
    public float fuerzaRebote = 15f;       // Fuerza con la que rebota hacia arriba
    public string tagRebote = "Rebotable"; // Tag del objeto con el que rebota

    private Rigidbody2D rb;
    private bool atacandoCaida = false;    // ¿Está haciendo el ataque de caída?

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Presiona X mientras estás en el aire para hacer el ataque de caída
        if (Input.GetKeyDown(KeyCode.X) && !EstaEnSuelo())
        {
            IniciarAtaqueCaida();
        }
    }

    void IniciarAtaqueCaida()
    {
        atacandoCaida = true;

        // Cancela cualquier velocidad vertical y empuja hacia abajo fuerte
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, -fuerzaCaida);

        Debug.Log("¡Ataque en caída!");
    }

    void OnCollisionEnter2D(Collision2D colision)
    {
        // Solo actúa si estaba haciendo el ataque de caída
        if (!atacandoCaida) return;

        // Comprueba si el objeto tiene el tag de rebote
        if (colision.gameObject.CompareTag(tagRebote))
        {
            Rebotar();
        }
        else
        {
            // Si golpea algo sin el tag, simplemente cancela el ataque
            atacandoCaida = false;
        }
    }

    void Rebotar()
    {
        atacandoCaida = false;

        // Lanza al jugador hacia arriba
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaRebote);

        Debug.Log("¡Rebote!");
    }

    // Comprueba si el jugador está tocando el suelo
    bool EstaEnSuelo()
    {
        // Lanza un pequeño raycast hacia abajo para detectar el suelo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f);
        return hit.collider != null;
    }
}
