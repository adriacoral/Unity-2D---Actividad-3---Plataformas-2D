using UnityEngine;
using UnityEngine.InputSystem;

// Ataque normal - ponlo en el mismo GameObject que el jugador
[RequireComponent(typeof(Rigidbody2D))]
public class AtaqueNormal : MonoBehaviour
{
    [Header("Configuración del ataque")]
    public float radioAtaque = 0.5f;       // Tamaño del golpe
    public int dañoAtaque = 10;            // Daño del ataque
    public Transform puntoAtaque;          // Objeto hijo que marca dónde golpea
    public LayerMask capaEnemigos;         // Capa de los enemigos

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Pulsa Z para atacar
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            Atacar();
        }
    }

    void Atacar()
    {
        if (anim != null)
            anim.SetTrigger("Atacar");

        Collider2D[] golpeados = Physics2D.OverlapCircleAll(puntoAtaque.position, radioAtaque, capaEnemigos);

        foreach (Collider2D enemigo in golpeados)
        {
            Debug.Log("Golpeaste a: " + enemigo.name);
            enemigo.GetComponent<EnemyHealth>()?.RecibirDaño(dañoAtaque); // 👈 esta línea
        }
    }
    // Muestra el área de ataque en la ventana Scene
    void OnDrawGizmosSelected()
    {
        if (puntoAtaque == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(puntoAtaque.position, radioAtaque);
    }
}
