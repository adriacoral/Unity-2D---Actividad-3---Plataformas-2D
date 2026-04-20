using UnityEngine;

public class AtaqueNormal : MonoBehaviour
{
    [Header("Configuración del ataque")]
    public float radioAtaque = 0.5f;       // Radio del área de golpe
    public int dañoAtaque = 10;            // Daño que hace el ataque
    public Transform puntoAtaque;          // Punto desde donde sale el golpe (pon un objeto hijo aquí)
    public LayerMask capaEnemigos;         // Selecciona la capa de los enemigos en el Inspector

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Presiona Z para atacar (puedes cambiarlo a lo que quieras)
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Atacar();
        }
    }

    void Atacar()
    {
        // Reproduce la animación de ataque (debe llamarse "Atacar" en el Animator)
        if (anim != null)
            anim.SetTrigger("Atacar");

        // Detecta todos los enemigos dentro del radio del punto de ataque
        Collider2D[] enemigosGolpeados = Physics2D.OverlapCircleAll(puntoAtaque.position, radioAtaque, capaEnemigos);

        // A cada enemigo que toque, le aplica daño
        foreach (Collider2D enemigo in enemigosGolpeados)
        {
            Debug.Log("Golpeaste a: " + enemigo.name);

            // Si el enemigo tiene un script con la función RecibirDaño(), la llama
            // (puedes adaptar esto a tu sistema de vida)
            // enemigo.GetComponent<Enemigo>().RecibirDaño(dañoAtaque);
        }
    }

    // Dibuja el área de ataque en la ventana Scene para facilitar el ajuste
    void OnDrawGizmosSelected()
    {
        if (puntoAtaque == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(puntoAtaque.position, radioAtaque);
    }
}
