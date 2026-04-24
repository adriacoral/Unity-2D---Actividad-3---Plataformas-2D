using UnityEngine;
using System.Collections.Generic;

// Ponlo en el jugador - guarda las llaves que ha recogido
public class InventarioJugador : MonoBehaviour
{
    private List<string> llaves = new List<string>();

    public void AgregarLlave(string id)
    {
        if (!llaves.Contains(id))
            llaves.Add(id);
    }

    public bool TieneLlave(string id)
    {
        return llaves.Contains(id);
    }

    public void EliminarLlave(string id)
    {
        llaves.Remove(id); // Llama a esto si la llave se consume al usarla
    }
}
