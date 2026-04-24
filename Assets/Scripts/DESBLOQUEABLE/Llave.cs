using UnityEngine;

// Ponlo en el objeto llave
public class Llave : MonoBehaviour
{
    public string idLlave = "llave_1"; // Cambia el id si tienes varias llaves distintas

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            // Guarda en el jugador que tiene esta llave
            InventarioJugador inventario = otro.GetComponent<InventarioJugador>();
            if (inventario != null)
            {
                inventario.AgregarLlave(idLlave);
                Debug.Log("Llave recogida: " + idLlave);
                Destroy(gameObject); // Desaparece al recogerla
            }
        }
    }
}
