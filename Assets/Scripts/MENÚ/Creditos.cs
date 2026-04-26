using UnityEngine;
using UnityEngine.SceneManagement;

// Ponlo en un GameObject vacío de la escena de créditos
public class Creditos : MonoBehaviour
{
    public string escenaMenu = "MenuPrincipal"; // Nombre exacto de tu escena del menú

    public void BotonVolver()
    {
        SceneManager.LoadScene(escenaMenu);
    }
}
