using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;  // Velocidad de movimiento normal del jugador
    public float slowSpeed = 2f; // Velocidad de movimiento cuando Shift izquierdo está presionado
    public Vector3 startPosition = new Vector3(25, 0.1f, 27); // Posición inicial del jugador

    void Start()
    {
        // Establece la posición inicial del jugador
        transform.position = startPosition;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Comprobar si la tecla Shift izquierdo está siendo presionada
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Mover al jugador más lentamente si Shift está presionado
            transform.Translate(movement * slowSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            // Mover al jugador a velocidad normal
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
    }
}
