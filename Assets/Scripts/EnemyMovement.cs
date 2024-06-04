using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float movementDistance = 10.0f;
    private Vector3 originalPosition;
    private bool movingRight = true;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Movimiento horizontal de lado a lado
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x > originalPosition.x + movementDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < originalPosition.x - movementDistance)
            {
                movingRight = true;
            }
        }
    }
}
