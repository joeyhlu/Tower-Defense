using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Wave Settings")]
    public GameObject enemyPrefab;       
    public Transform[] waypoints;        
    public float spawnDelay = 1f;       
    public int enemiesPerWave = 5;       
    public float waveInterval = 5f;     

    private bool waveInProgress = false;
    private int waveIndex = 0;

    void Update()
    {
        if (!waveInProgress)
        {
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        waveInProgress = true;
        waveIndex++;

        for (int i = 0; i < enemiesPerWave; i++)
        {
            GameObject enemyObj = Instantiate(enemyPrefab, waypoints[0].position, Quaternion.identity);

            EnemyPathMovement enemyMovement = enemyObj.GetComponent<EnemyPathMovement>();
            enemyMovement.waypoints = waypoints;

            yield return new WaitForSeconds(spawnDelay);
        }

        yield return new WaitForSeconds(waveInterval);

        waveInProgress = false;
    }
}
