using UnityEngine;

public class plataformaMovimiento : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject ObjetoAmover;

    public Transform StartPoint;
    public Transform EndPoint;

    public float Velocity;

    private Vector3 MoverHacia;  


    void Start()
    {
      MoverHacia = EndPoint.position;  
    }

    // Update is called once per frame
    void Update()
    {
        ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, MoverHacia, Velocity * Time.deltaTime);
    }
}
