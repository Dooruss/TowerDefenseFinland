using Cinemachine;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [Tooltip("Amount of enemies spawning per interval")]
    [SerializeField] private float spawnCount; // amount of enemies spawning per interval
    [Tooltip("Time between each spawn")]
    [SerializeField] private int spawnInterval; // the time between each spawn
    private int spawnTime;

    [Header("Paralel stuff")]
    [Tooltip("Enable if u use a split path")]
    public bool ParalelTrack;
    [Tooltip("If u plan on using path with multiple ways, put paths in this (Currently only works with 1 split)")]
    [SerializeField] public CinemachinePath[] ParalelPaths;

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
