using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerShootAura : MonoBehaviour
{
    public float timer = 0f;
    public float shootSpeed = 3f;
    public ParticleSystem particles;
    public int damage = 50;
    public List<GameObject> EnemyList;
    public GameObject speer;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > shootSpeed)
        {
            if (EnemyList.Count != 0)
            {
                foreach (var enemy in EnemyList)
                {
                    if (enemy == null)
                    {
                        EnemyList.Remove(enemy);
                    }
                    else
                    {
                        IEnemy enemyInterface = enemy.GetComponent<IEnemy>();
                        enemyInterface.Kill(damage);
                        Debug.Log("Damaged" + enemy.name);
                        GameObject SpawnedSpeer = Instantiate(speer, this.gameObject.transform);
                        ShootSpeer script = SpawnedSpeer.GetComponent<ShootSpeer>();
                        SpawnedSpeer.transform.localScale = new Vector3(0.03333334f, 0.006666666f, 0.006666666f);
                        script.objectToHit = enemy.transform;
                        

                    }
                }
                particles.Play();
                timer = 0f;
            }
        }
    }

    //when the eney enter add them to the list
    //when they exit remove them from the list
    private void OnTriggerEnter(Collider other)
    {
        EnemyList.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        //get the name and then remove it
        string EnemeyName = other.name;
        //the word enemy is a placeholder variable representing each individual element in the EnemyList as the list is being searched.
        GameObject EnemyOBJ =  EnemyList.FirstOrDefault(enemy => enemy.name == EnemeyName);
        EnemyList.Remove(EnemyOBJ);

    }
}
