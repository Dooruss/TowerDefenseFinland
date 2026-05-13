using Cinemachine;
using UnityEngine;


public class Entity : MonoBehaviour
{
    public int NoteIndex;
    [SerializeField] protected int MaxHealth;
    public int CurrentHealth;
    [SerializeField] protected int MovementSpeed;
    [SerializeField] protected int AttackPower;
    protected CinemachineDollyCart cartScript;
    protected EnemySpawning Spawner;
    protected bool IsParalelTrack;
    [SerializeField] protected CinemachinePath[] AllPaths;
    protected MainTower MainTower;

    private void Start()
    {
        Spawner = FindAnyObjectByType<EnemySpawning>();
        cartScript = GetComponent<CinemachineDollyCart>();
        MainTower = FindAnyObjectByType<MainTower>();
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
        Destroy(gameObject);
    }
}
