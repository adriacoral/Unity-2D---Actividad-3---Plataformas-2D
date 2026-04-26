using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 3f;
    private Vector3 startPosition;
    private float direction = 1f;
    private Animator anim;
    private SpriteRenderer sr;

    void Start()
    {
        startPosition = transform.position;
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        float distanceMoved = transform.position.x - startPosition.x;

        if (distanceMoved >= moveDistance)
        {
            direction = -1f;
        }
        else if (distanceMoved <= -moveDistance)
        {
            direction = 1f;
        }

        // Flip según dirección
        if (sr) sr.flipX = direction < 0;

        // Animación walk
        if (anim) anim.SetBool("isWalking", speed > 0);
    }
}