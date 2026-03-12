using UnityEngine;

public class Plataforma : MonoBehaviour
{

    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2f;

    private Transform destinoActual;
    private Rigidbody2D rb; 

    void Start()
    {
        destinoActual = puntoB;
        rb = GetComponent<Rigidbody2D>(); 
    }

   
    void FixedUpdate() 
    {
        
        Vector2 nuevaPosicion = Vector2.MoveTowards(rb.position, destinoActual.position, velocidad * Time.fixedDeltaTime);
        
       
        rb.MovePosition(nuevaPosicion);

        
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

