using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Velocidad del enemigo
    public float speed = 2f;

    // Distancia que recorre antes de dar vuelta
    public float moveDistance = 3f;

    // Posición inicial guardada al inicio
    private Vector3 startPosition;

    // Dirección actual (1 = derecha, -1 = izquierda)
    private float direction = 1f;

    void Start()
    {
        // Guardar posición de inicio
        startPosition = transform.position;
    }

    void Update()
    {
        // Mover al enemigo en la dirección actual
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        // Calcular cuánto se ha alejado del punto de inicio
        float distanceMoved = transform.position.x - startPosition.x;

        // Si llegó al límite derecho o izquierdo, dar vuelta
        if (distanceMoved >= moveDistance)
        {
            direction = -1f; // Ir a la izquierda
        }
        else if (distanceMoved <= -moveDistance)
        {
            direction = 1f; // Ir a la derecha
        }
    }
}