using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int lives = 3; // Agrega una variable para las vidas
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            lives--; // Decrementa una vida
            if (lives > 0)
            {
                Debug.Log("Player lost a life. Remaining lives: " + lives);
                currentHealth = maxHealth; // Restaura la salud
                // Aquí puedes añadir una lógica de respawn o invulnerabilidad temporal
            }
            else
            {
                Debug.Log("Game Over!");
                Die();
            }
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        // Implementar lógica de Game Over o reiniciar el nivel
        gameObject.SetActive(false); // Desactiva el jugador (o destrúyelo si prefieres)
    }
}
