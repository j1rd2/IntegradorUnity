using UnityEngine;

public class EnemyShooter : MonoBehaviour
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
            Fire();
            shootCooldown = shootingRate;
        }
    }

    private void Fire()
    {
        // Usar la rotación del enemigo y ajustar la posición de inicio de la bala
        Instantiate(bulletPrefab, transform.position + bulletOffset, transform.rotation);
    }
}
