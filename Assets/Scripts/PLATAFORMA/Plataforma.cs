using UnityEngine;

public class Plataforma : MonoBehaviour
{

    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2f;

    private Transform destinoActual;
    private Rigidbody2D rb; // Creamos un hueco para el Rigidbody

    void Start()
    {
        destinoActual = puntoB;
        rb = GetComponent<Rigidbody2D>(); // Le decimos que use el Rigidbody de la plataforma
    }

    // Cambiamos Update por FixedUpdate (es la regla de oro cuando movemos físicas)
    void FixedUpdate() 
    {
        // Calculamos la nueva posición
        Vector2 nuevaPosicion = Vector2.MoveTowards(rb.position, destinoActual.position, velocidad * Time.fixedDeltaTime);
        
        // Movemos la plataforma usando las físicas (MovePosition)
        rb.MovePosition(nuevaPosicion);

        // Comprobamos si llegó al destino para cambiar de dirección
        if (Vector2.Distance(rb.position, destinoActual.position) < 0.1f)
        {
            if (destinoActual == puntoB)
            {
                destinoActual = puntoA;
            }
            else
            {
                destinoActual = puntoB;
            }
        }
    }
}

