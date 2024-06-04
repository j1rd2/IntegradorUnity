using UnityEngine;

public class EnemyCircularMovement : MonoBehaviour
{
    public float speed = 50.0f;
    public float radius = 5.0f;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        transform.position = originalPosition + new Vector3(Mathf.Cos(Time.time * speed) * radius, 0, Mathf.Sin(Time.time * speed) * radius);
    }
}
