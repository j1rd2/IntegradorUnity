using UnityEngine;

public class EnemyForwardBackwardMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float movementDistance = 5.0f;
    private Vector3 originalPosition;
    private bool movingForward = true;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (movingForward)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (transform.position.z > originalPosition.z + movementDistance)
            {
                movingForward = false;
            }
        }
        else
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            if (transform.position.z < originalPosition.z - movementDistance)
            {
                movingForward = true;
            }
        }
    }
}
