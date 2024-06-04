using UnityEngine;

public class CombinedShooter : MonoBehaviour
{
public GameObject bulletPrefab;
    public float shootingRate = 0.5f;
    private float shootCooldown;
    private int currentMode = 0; // Índice del modo actual
    public int floralBulletCount = 20;
    public int spiralBulletCount = 10;
    private float angleOffset = 0; // Offset de ángulo para el disparo en espiral
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0); // Desplazamiento de la bala
    private float modeChangeTimer = 10f; // Temporizador para el cambio de modo

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }

        if (shootCooldown <= 0)
        {
            switch (currentMode)
            {
                case 0:
                    FireFloral();
                    break;
                case 1:
                    FireSpiral();
                    break;
                case 2:
                    FireRandom();
                    break;
            }
            shootCooldown = shootingRate;
        }

        // Temporizador para cambio de modos
        if (modeChangeTimer > 0)
        {
            modeChangeTimer -= Time.deltaTime;
        }
        else
        {
            modeChangeTimer = 10f;
            currentMode = (currentMode + 1) % 3; // Cambia al siguiente modo y vuelve al inicio después del último
        }
    }

    private void FireFloral()
    {
        float angleStep = 360f / floralBulletCount;
        for (int i = 0; i < floralBulletCount; i++)
        {
            float angle = i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, angle, 0) * transform.rotation;
            Instantiate(bulletPrefab, transform.position + bulletOffset, rotation);
        }
    }

    private void FireSpiral()
    {
        float angleStep = 360f / spiralBulletCount;
        for (int i = 0; i < spiralBulletCount; i++)
        {
            float angle = angleOffset + i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, angle, 0) * transform.rotation;
            Instantiate(bulletPrefab, transform.position + bulletOffset, rotation);
        }
        angleOffset += 10; // Aumentar el offset para cada disparo, creando un efecto de espiral
    }

        private void FireRandom()
    {
        for (int i = 0; i < spiralBulletCount; i++) // Reutilizamos el contador de espiral para simplificar
        {
            float angle = Random.Range(0, 360); // Genera un ángulo aleatorio
            Quaternion rotation = Quaternion.Euler(0, angle, 0) * transform.rotation;
            Instantiate(bulletPrefab, transform.position + bulletOffset, rotation);
        }
    }

}

