using UnityEngine;

public class Plataforma : MonoBehaviour
{

    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2f;

    private Transform destinoActual;

    void Start()
    {
        destinoActual = puntoB;
    }

   
    void Update() 
    {

        transform.position = Vector2.MoveTowards(transform.position, destinoActual.position, velocidad * Time.deltaTime);

        
        if (Vector2.Distance(transform.position, destinoActual.position) < 0.1f)
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

