using UnityEngine;

public class EnemyVerticalMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float movementDistance = 5.0f;
    private Vector3 originalPosition;
    private bool movingUp = true;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (transform.position.y > originalPosition.y + movementDistance)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (transform.position.y < originalPosition.y - movementDistance)
            {
                movingUp = true;
            }
        }
    }
}
