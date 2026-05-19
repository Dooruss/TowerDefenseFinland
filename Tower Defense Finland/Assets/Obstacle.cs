using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public List<GameObject> EnemyList;
    [SerializeField] private float timer;
    public float MaxHealth = 20;
    public float CurrentHealth;
    public Image HealthBarFill;
    //if an enemy enters stop them
    //if enemy has enetered do damage to the obstacle
    //if obstacle is broken resume enemy

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
    private void Update()
    {
        HealthBarFill.fillAmount = (float)CurrentHealth / (float)MaxHealth;
        timer += Time.deltaTime;

        if(EnemyList.Count >0 && timer > 1f)
        {
            foreach (GameObject enemy in EnemyList)
            {
                //stop enemy
                
                Enemy_1 enemyScipt = enemy.GetComponent<Enemy_1>();
                CurrentHealth -= enemyScipt.AttackPower;
                //Debug.Log("Damaged the obstaicle with " + enemyScipt.AttackPower + "By" +enemy.name);
            }
            timer = 0f;
        }
        if (CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IEnemy TriggerBoxEnemy= other.gameObject.GetComponent<IEnemy>();
        if (TriggerBoxEnemy != null)
        {
            EnemyList.Add(other.gameObject);
        }
    }


}
