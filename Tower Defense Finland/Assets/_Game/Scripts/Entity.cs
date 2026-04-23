using UnityEngine;

public class Entity : MonoBehaviour
{
    public int NoteIndex;
    [SerializeField] protected int MaxHealth;
    public int CurrentHealth;
    [SerializeField] protected int MovementSpeed;
    [SerializeField] protected int AttackPower;
    [SerializeField] protected int AttackSpeed;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    virtual public void CheckDeath()
    {
        if (CurrentHealth <= 0)
        {
            OnDeath();
        }
    }

    virtual public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    virtual public void OnDeath()
    {
        Destroy(gameObject);
    }
}
