using UnityEngine;

public class FireAreaLvl1 : MonoBehaviour
{
    public GameObject EnemyToDamage;
    private IEnemy enemy;
    public float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        
        if(EnemyToDamage == null && enemy != null)
        {
            enemy = null;
        }else if(EnemyToDamage != null )
        {
            if(enemy == null)
            {
                enemy = EnemyToDamage.GetComponent<IEnemy>();
            }
            if(timer > 1)
            {
                Debug.Log("Damage Enemy");
                enemy.Kill(2);
                timer = 0;
            }
        }

        Destroy(this.gameObject, 5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        EnemyToDamage = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        EnemyToDamage = null;
    }
}
