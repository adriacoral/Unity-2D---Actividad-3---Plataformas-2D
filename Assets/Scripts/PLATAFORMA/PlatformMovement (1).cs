using UnityEngine;

// 📦 SCRIPT 1: Mueve la plataforma de un lado a otro
// ✅ Usa Rigidbody2D → Body Type: Kinematic

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 2f;
    public float distancia = 3f;

    private Rigidbody2D rb;
    private Vector2 puntoInicio;
    private int direccion = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        puntoInicio = rb.position;
    }

    void FixedUpdate()
    {
        Vector2 nuevaPosicion = rb.position + Vector2.right * velocidad * direccion * Time.fixedDeltaTime;
        rb.MovePosition(nuevaPosicion); // ✅ mover con física, no con transform

        float distanciaRecorrida = rb.position.x - puntoInicio.x;
        if (distanciaRecorrida >= distancia)  direccion = -1;
        if (distanciaRecorrida <= -distancia) direccion = 1;
    }
}
