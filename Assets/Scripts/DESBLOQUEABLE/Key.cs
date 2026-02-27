using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerKeys Player = other.GetComponentInParent<PlayerKeys>();
        if (Player != null)
        {
            Player.AddKey();
            Destroy(gameObject);
        }
    }
}
