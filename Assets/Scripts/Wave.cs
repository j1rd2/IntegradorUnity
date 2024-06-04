using UnityEngine;

public class Wave : MonoBehaviour
{
    private WaveManager waveManager;
    private int enemiesAlive;

    public void Initialize(WaveManager manager)
{
    waveManager = manager;
    foreach (Transform child in transform)
    {
        EnemyHealth enemyHealth = child.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.OnDeath += OnEnemyDeath;
        }
        else
        {
            Debug.LogError("EnemyHealth component missing on enemy object", child.gameObject);
        }
    }
}
    private void OnEnemyDeath()
    {
        enemiesAlive--;
        if (enemiesAlive <= 0)
        {
            Destroy(gameObject); // Destruye la oleada actual
            waveManager.StartNextWave(); // Comienza la siguiente oleada
        }
    }
}
