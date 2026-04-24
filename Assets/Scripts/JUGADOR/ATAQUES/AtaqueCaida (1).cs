using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollisionDetector))]
public class AtaqueCaida : MonoBehaviour
{
    [Header("Configuración")]
    public float fuerzaCaida = 25f;
    public float fuerzaRebote = 20f;
    public string tagRebote = "Rebotable";

    private Rigidbody2D rb;
    private CircleCollisionDetector coll;
    private bool atacandoCaida = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollisionDetector>();
    }

    void Update()
    {
        if (Keyboard.current.xKey.wasPressedThisFrame && !coll.isColliding)
        {
            IniciarCaida();
        }

        if (atacandoCaida && coll.startedCollidingThisFrame)
        {
            atacandoCaida = false;
        }
    }

    void IniciarCaida()
    {
        atacandoCaida = true;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, -fuerzaCaida);
    }

    void OnCollisionEnter2D(Collision2D colision)
    {
        if (!atacandoCaida) return;

        if (colision.gameObject.CompareTag(tagRebote))
        {
            // Solo destruye si es un enemigo (tiene EnemyHealth)
            EnemyHealth enemigo = colision.gameObject.GetComponent<EnemyHealth>();
            if (enemigo != null)
            {
                Destroy(colision.gameObject);
                Debug.Log("Enemigo destruido!");
            }

            // Rebota siempre, sea enemigo o plataforma
            atacandoCaida = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaRebote);
        }
    }
}