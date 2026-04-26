using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Vida del enemigo")]
    public int vidaMaxima = 3;
    private int vidaActual;
    private Animator anim;
    private bool muerto = false;

    void Start()
    {
        vidaActual = vidaMaxima;
        anim = GetComponent<Animator>();
    }

    public void RecibirDaño(int cantidad)
    {
        if (muerto) return;

        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            Morir();
        }
        else
        {
            if (anim) anim.SetTrigger("hit");
        }
    }

    void Morir()
    {
        muerto = true;
        if (anim) anim.SetTrigger("dead");
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<EnemyContact>().enabled = false;
        Destroy(gameObject, 1.5f); // Espera que termine la animación
    }
}