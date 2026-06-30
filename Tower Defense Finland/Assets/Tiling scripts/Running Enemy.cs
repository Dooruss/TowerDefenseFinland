using Unity.AI.Navigation.Editor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RunningEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] NavMeshAgent agent;
    private Transform End;
    public float currentHealth;
    [SerializeField] float maxHealth = 100f;
    [SerializeField] Image HealthBarFill;
    private int MoneyAfterDeath = 40;
    [SerializeField] AudioClip Death_Sound;

    private void Start()
    {
        End = GameObject.Find("END").GetComponent<Transform>();
        currentHealth = maxHealth;
    }
    void Update()
    {
        agent.SetDestination(End.position);
        if(currentHealth <= 0)
        {
            AudioSource.PlayClipAtPoint(Death_Sound, new Vector3(-31 , 72 , 39) , 0.5f);
            MoneyManager moneyManager = GameObject.Find("GameManager").GetComponent<MoneyManager>();
            moneyManager.Money += MoneyAfterDeath;
            Destroy(this.gameObject);
        }
    }
    public void Kill(int damage)
    {
        currentHealth -= 10f;
        UpdateHealthBar();
    }
    virtual public void UpdateHealthBar()
    {
        HealthBarFill.fillAmount = (float)currentHealth / (float)maxHealth;
    }
}
