using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject prefabBala;          // Arrastra aquí el prefab de la bala
    public Transform puntoDisparo;         // Objeto hijo desde donde sale la bala
    public float intervaloDisparo = 2f;    // Segundos entre disparos
    public float velocidadBala = 8f;       // Velocidad de la bala
    public int dañoBala = 1;               // Daño que hace la bala al jugador

    private float timerDisparo = 0f;
    private Transform jugador;

    void Start()
    {
        // Busca al jugador automáticamente por su tag (asegúrate de que tu jugador tenga el tag "Player")
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if (obj != null) jugador = obj.transform;
    }

    void Update()
    {
        timerDisparo += Time.deltaTime;

        // Dispara cada X segundos
        if (timerDisparo >= intervaloDisparo)
        {
            timerDisparo = 0f;
            Disparar();
        }
    }

    void Disparar()
    {
        if (prefabBala == null || puntoDisparo == null) return;

        // Calcula la dirección hacia el jugador
        Vector2 direccion = Vector2.right; // Dirección por defecto: derecha
        if (jugador != null)
        {
            direccion = (jugador.position - puntoDisparo.position).normalized;
        }

        // Crea la bala y le aplica velocidad
        GameObject bala = Instantiate(prefabBala, puntoDisparo.position, Quaternion.identity);
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
        if (rbBala != null)
        {
            rbBala.linearVelocity = direccion * velocidadBala;
        }

        // Le pasa el daño a la bala para que sepa cuánto hacer
        Bala scriptBala = bala.GetComponent<Bala>();
        if (scriptBala != null)
        {
            scriptBala.daño = dañoBala;
        }

        Debug.Log("Enemigo disparó!");
    }
}
