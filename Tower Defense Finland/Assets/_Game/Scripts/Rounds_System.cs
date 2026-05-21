using TMPro;
using UnityEngine;

public class Rounds_System : MonoBehaviour
{
    [SerializeField] private int currentRound = 1;
    [SerializeField] private TextMeshProUGUI Round_Text;
    public int AmountEnemiesToSpawn = 10;
    public int EnemiesSpawnedThisRound;
    public int EnemiesKilledThisRound;
    private EnemySpawning EnemySpawner;

    void Start()
    {
        Round_Text.text = $"Round: {currentRound}";
        EnemySpawner = FindAnyObjectByType<EnemySpawning>();
    }

    void Update()
    {
        if (EnemiesKilledThisRound >= AmountEnemiesToSpawn)
        {
            NextRound();
        }
    }

    void NextRound()
    {
        currentRound += 1;
        AmountEnemiesToSpawn += Random.Range(1, 10);
        EnemiesSpawnedThisRound = 0;
        EnemiesKilledThisRound = 0;
        Round_Text.text = $"Round: {currentRound}";
    }
}
