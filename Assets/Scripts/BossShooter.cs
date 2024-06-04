using UnityEngine;

public class BossShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootingRate = 0.5f;  // Un disparo más rápido para el efecto bullet hell
    private float shootCooldown;
    public int bulletCount = 20;       // Número de balas en un solo disparo floral
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0); // Desplazamiento de la bala

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
            Fire();
            shootCooldown = shootingRate;
        }
    }

    private void Fire()
    {
        float angleStep = 360f / bulletCount;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, angle, 0) * transform.rotation;
            // Añadir el bulletOffset a la posición de instanciación
            Instantiate(bulletPrefab, transform.position + bulletOffset, rotation);
        }
    }
}
