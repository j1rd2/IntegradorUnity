using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float shootingRate = 0.5f;
    private float shootCooldown;

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

        if (Input.GetButtonDown("Fire1") && shootCooldown <= 0)  // Usar el nombre del input que configuraste
        {
            Fire();
            shootCooldown = shootingRate;
        }
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }
}
