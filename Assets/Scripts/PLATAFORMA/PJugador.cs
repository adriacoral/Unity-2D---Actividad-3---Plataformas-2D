using UnityEngine;

public class PJugador : MonoBehaviour
{
    private Transform jugador;
    private Vector3 posicionAnterior;
    void Start()
    {
        posicionAnterior = transform.position;
    }


    void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Player"))
        {
            jugador = colision.transform;
        }
    }

    void OnTriggerExit2D(Collider2D colision)
    {
        if (colision.CompareTag("Player"))
        {
            jugador = null;
        }
    }
}
