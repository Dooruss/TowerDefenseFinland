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

    private void Start()
    {
        CurrentHealth = MaxHealth;
        cartScript = GetComponent<CinemachineDollyCart>();
        if (cartScript.m_Path == null)
        {
            cartScript.m_Path = FindAnyObjectByType<CinemachinePath>();
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
