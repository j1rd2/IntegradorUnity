using UnityEngine;

public class TridentShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootingRate = 2f;
    private float shootCooldown;

    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0); // Ajusta este valor según sea necesario

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }

        if (shootCooldown <= 0)
        {
            FireTrident();
            shootCooldown = shootingRate;
        }
    }

    private void FireTrident()
    {
        // Disparo central
        Instantiate(bulletPrefab, transform.position + bulletOffset, transform.rotation);

        // Disparo izquierdo con ángulo ajustado solo en el plano XZ
        Instantiate(bulletPrefab, transform.position + bulletOffset, transform.rotation * Quaternion.Euler(0, -10, 0));

        // Disparo derecho con ángulo ajustado solo en el plano XZ
        Instantiate(bulletPrefab, transform.position + bulletOffset, transform.rotation * Quaternion.Euler(0, 10, 0));
    }
}
