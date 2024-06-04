using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] waves; // Incluye todas las oleadas y el Boss como último elemento
    private int currentWaveIndex = 0;

    void Start()
    {
        StartNextWave(); // Inicia la primera oleada
    }

    public void StartNextWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            GameObject wave = Instantiate(waves[currentWaveIndex]); // Instancia la oleada
            wave.GetComponent<Wave>().Initialize(this);
            currentWaveIndex++;
        }
        else
        {
            Debug.Log("All waves completed!");
        }
    }
}
