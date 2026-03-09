using UnityEngine;

// 📦 SCRIPT 1: Mueve la plataforma de un lado a otro
// Pon este script en el GameObject de la plataforma

public class PlatformMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 2f;
    public float distancia = 3f; // cuánto se aleja del punto inicial

    private Vector3 puntoInicio;
    private int direccion = 1;

    void Start()
    {
        puntoInicio = transform.position;
    }

    void Update()
    {
        Moverse();
        CambiarDireccion();
    }

    void Moverse()
    {
        transform.Translate(Vector2.right * velocidad * direccion * Time.deltaTime);
    }

    void CambiarDireccion()
    {
        float distanciaRecorrida = transform.position.x - puntoInicio.x;

        if (distanciaRecorrida >= distancia)
            direccion = -1;

        if (distanciaRecorrida <= -distancia)
            direccion = 1;
    }
}
