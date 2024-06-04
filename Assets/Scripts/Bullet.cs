using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 100;
    public float speed = 2f; // Velocidad a la que la bala se moverá
    public float lifetime = 5f; // Tiempo de vida de la bala en segundos

    void Start()
    {
        Destroy(gameObject, lifetime); // Destruye la bala después de 'lifetime' segundos
    }

    void Update()
    {
        // Mover la bala hacia adelante cada frame
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Comprobación para el daño a los enemigos por una bala del jugador
        if (collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("PlayerBullet"))
        {
            var enemyHealth = collision.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
            return; // Evita que se ejecuten más comprobaciones
        }

        // Comprobación para el daño al jugador por una bala del enemigo
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("EnemyBullet"))
        {
            var playerHealth = collision.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
            return;
        }

        // Evitar que las balas de enemigo dañen a otros enemigos
        if (collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("EnemyBullet"))
        {
            return; // No hacer nada si una bala de enemigo colisiona con otro enemigo
        }
    }
}
