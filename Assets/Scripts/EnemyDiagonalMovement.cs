using UnityEngine;

public class EnemyDiagonalMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float movementDistance = 7.0f;
    private Vector3 originalPosition;
    private bool movingOut = true;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Calcula la dirección de movimiento en el plano XZ
        Vector3 moveDirection = (movingOut ? new Vector3(1, 0, 1) : new Vector3(-1, 0, -1)).normalized;

        // Mueve el enemigo en la dirección calculada
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Controla el cambio de dirección basado en la distancia desde la posición original
        if (movingOut && (transform.position - originalPosition).magnitude > movementDistance)
        {
            movingOut = false;
        }
        else if (!movingOut && (transform.position - originalPosition).magnitude < 1)
        {
            movingOut = true;
        }
    }
}
