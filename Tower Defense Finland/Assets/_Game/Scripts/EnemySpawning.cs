using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnCount; // amount of enemies spawning per interval
    [SerializeField] private int spawnInterval; // the time between each spawn
    private int spawnTime;

    private void Start()
    {
        spawnTime = spawnInterval;
    }

    void Update()
    {
        spawnTime--;
        if (spawnTime < 0)
        {
            SpawnEnemy();
            spawnTime = spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
