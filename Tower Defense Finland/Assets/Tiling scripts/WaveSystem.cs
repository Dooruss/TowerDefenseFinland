using System.Collections;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] TilingGameManager gameManager;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform start;
    [SerializeField] float SpawnInterval = 3f;


    void Start()
    {
        StartCoroutine(EnemyWaves());
    }

    IEnumerator EnemyWaves()
    {
        while (gameManager.Health > 0)
        {
            Instantiate(enemy, start.transform.position, start.transform.rotation);
            yield return new WaitForSeconds(SpawnInterval);
        }
    }
}
