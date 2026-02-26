using UnityEngine;

public class JugadorPlataforma : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlataformaMovible")
        { 
            transform.parent = collision.transform;
        
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlataformaMovible")
        {
            transform.parent = null;

        }
    }
}
