using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public string escenaJuego = "Juego";
    public string escenaCreditos = "Creditos";

    public void BotonJugar()
    {
        SceneManager.LoadScene(escenaJuego);
    }

    public void BotonCreditos()
    {
        SceneManager.LoadScene(escenaCreditos);
    }

    public void BotonSalir()
    {
        Application.Quit();
    }
}

