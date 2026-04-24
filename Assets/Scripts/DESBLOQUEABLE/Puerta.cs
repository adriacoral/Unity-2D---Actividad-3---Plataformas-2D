using UnityEngine;

// Ponlo en la puerta, cofre, fusible... lo que quieras desbloquear
public class Puerta : MonoBehaviour
{
    public string idLlaveNecesaria = "llave_1"; // Tiene que coincidir con el id de la Llave
    public bool consumirLlave = true;           // true = la llave desaparece al usarla

    private bool abierta = false;

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (abierta) return;
        if (!otro.CompareTag("Player")) return;

        InventarioJugador inventario = otro.GetComponent<InventarioJugador>();
        if (inventario == null) return;

        if (inventario.TieneLlave(idLlaveNecesaria))
        {
            Abrir(inventario);
        }
        else
        {
            Debug.Log("Necesitas la llave: " + idLlaveNecesaria);
        }
    }

    void Abrir(InventarioJugador inventario)
    {
        abierta = true;

        if (consumirLlave)
            inventario.EliminarLlave(idLlaveNecesaria);

        Debug.Log("¡Abierto!");

        // Aquí puedes hacer lo que quieras al abrirse:
        Destroy(gameObject);          // Opción 1: desaparece (puerta que se abre)
        // gameObject.SetActive(false); // Opción 2: se desactiva
        // anim.SetTrigger("Abrir");    // Opción 3: reproduce animación de apertura
    }
}
