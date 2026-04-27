using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;                               // TextMeshPro

public class NPCInteractuable : MonoBehaviour
{
    [Header("Texto del NPC")]
    [TextArea] public string mensaje = "¡Hola! Soy un NPC.";

    [Header("Referencias UI")]
    public GameObject globoTexto;
    public TMP_Text textoUI;

    private bool jugadorCerca = false;
    private bool globoVisible = false;

    void Start()
    {
        if (textoUI != null) textoUI.text = mensaje;
        if (globoTexto != null) globoTexto.SetActive(false);
    }

    void Update()
    {
        if (jugadorCerca && Keyboard.current.eKey.wasPressedThisFrame)
        {
            globoVisible = !globoVisible;
            if (globoTexto != null) globoTexto.SetActive(globoVisible);
            Debug.Log("E pulsado! Globo: " + globoVisible);
        }
    }

    // Cuando algo entra en el trigger del NPC
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            jugadorCerca = true;
            Debug.Log("Jugador entró en zona NPC");
        }
    }

    // Cuando algo sale del trigger del NPC
    void OnTriggerExit2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            jugadorCerca = false;
            globoVisible = false;
            if (globoTexto != null) globoTexto.SetActive(false);
            Debug.Log("Jugador salió de zona NPC");
        }
    }
}
