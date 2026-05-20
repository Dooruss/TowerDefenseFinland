using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    public int NoteIndex;
    [SerializeField] protected int MaxHealth;
    public int CurrentHealth;
    protected float MovementSpeed;
    [SerializeField] public int AttackPower;
    protected CinemachineDollyCart cartScript;
    public bool IsMoving = true;
    protected EnemySpawning Spawner;
    protected Rounds_System RoundSystem_Script;
    protected bool IsParalelTrack;
    [SerializeField] protected CinemachinePath[] AllPaths;
    protected MainTower MainTower;
    public Image HealthBarFill;

    private void Start()
    {
        Spawner = FindAnyObjectByType<EnemySpawning>();
        cartScript = GetComponent<CinemachineDollyCart>();
        MainTower = FindAnyObjectByType<MainTower>();
        RoundSystem_Script = FindAnyObjectByType<Rounds_System>();
        CurrentHealth = MaxHealth;
        MovementSpeed = cartScript.m_Speed;
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
        ExtraStartFunc();
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
        if (AttacksTower == false)
        {
            MainTower.money += 100;
        }
        Destroy(gameObject);
    }

    virtual public void StopEnemy()
    {
        IsMoving = false;
        cartScript.m_Speed = 0;
    }

    virtual public void ResumeEnemy()
    {
        IsMoving = true;
        cartScript.m_Speed = MovementSpeed;
    }
    virtual public void UpdateHealthBar()
    {
        HealthBarFill.fillAmount = (float)CurrentHealth / (float)MaxHealth;
    }

    virtual public void ExtraStartFunc()
    {
        // incase u want to add extra functionality to the enemy without making a new script
    }
}
