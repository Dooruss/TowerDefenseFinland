using Cinemachine;
using UnityEngine;


public class Entity : MonoBehaviour
{
    public int NoteIndex;
    [SerializeField] protected int MaxHealth;
    public int CurrentHealth;
    [SerializeField] protected int MovementSpeed;
    [SerializeField] public int AttackPower;
    protected CinemachineDollyCart cartScript;
    protected EnemySpawning Spawner;
    protected Rounds_System RoundSystem_Script;
    protected bool IsParalelTrack;
    [SerializeField] protected CinemachinePath[] AllPaths;
    protected MainTower MainTower;

    private void Start()
    {
        Spawner = FindAnyObjectByType<EnemySpawning>();
        cartScript = GetComponent<CinemachineDollyCart>();
        MainTower = FindAnyObjectByType<MainTower>();
        RoundSystem_Script = FindAnyObjectByType<Rounds_System>();
        CurrentHealth = MaxHealth;
        if (Spawner != null)
        {
            if (Spawner.ParalelTrack) // if the path has multiple routes
            {
                IsParalelTrack = true;
                AllPaths = Spawner.ParalelPaths;
                cartScript.m_Path = AllPaths[0];
            }
            else { cartScript.m_Path = FindAnyObjectByType<CinemachinePath>(); }
        }
    }

    virtual public void CheckDeath()
    {
        if (CurrentHealth <= 0)
        {
            OnDeath(false);
        }
    }

    virtual public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    virtual public void OnDeath(bool AttacksTower)
    {
        RoundSystem_Script.EnemiesKilledThisRound += 1;
        Destroy(gameObject);
    }
}
