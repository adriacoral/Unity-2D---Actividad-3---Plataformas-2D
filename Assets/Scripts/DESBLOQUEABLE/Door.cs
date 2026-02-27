using UnityEngine;

public class Door : MonoBehaviour
{
    public Collider2D blockingCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnTriggerEnter2D(Collider2D other)
    {
        PlayerKeys player = other.GetComponent<PlayerKeys>();
        
        if (player != null)
        {
           bool dooropen = player.UseKey();

            if (dooropen)
            {

                if(blockingCollider != null)
                {
                    blockingCollider.enabled = false;
                }
                Destroy(gameObject);
            }
        }
    
        
    }
}
