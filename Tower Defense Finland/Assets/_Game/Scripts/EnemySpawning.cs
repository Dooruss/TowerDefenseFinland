using Cinemachine;
using JetBrains.Annotations;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [Tooltip("Amount of enemies spawning per interval")]
    [SerializeField] private float spawnCount; // amount of enemies spawning per interval
    private Rounds_System RoundSystem_Script;
    private int MaxAmountOfSpawn;
    [Tooltip("Time between each spawn")]
    [SerializeField] private float spawnInterval; // the time between each spawn
    private float spawnTime;
    [Header("Paralel stuff")]
    [Tooltip("Enable if u use a split path")]
    public bool ParalelTrack;
    [Tooltip("If u plan on using path with multiple ways, put paths in this (Currently only works with 1 split)")]
    [SerializeField] public CinemachinePath[] ParalelPaths;

    private void Start()
    {
        spawnTime = spawnInterval;
        RoundSystem_Script = FindAnyObjectByType<Rounds_System>();
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;
        MaxAmountOfSpawn = RoundSystem_Script.AmountEnemiesToSpawn;
        if (spawnTime < 0 && RoundSystem_Script.EnemiesSpawnedThisRound < MaxAmountOfSpawn)
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
            RoundSystem_Script.EnemiesSpawnedThisRound += 1;
        }
    }
}
