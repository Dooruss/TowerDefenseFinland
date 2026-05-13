using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class FireTower : MonoBehaviour
{
    public float timer = 0f;
    public float shootSpeed = 3f;
    public ParticleSystem particles;
    public int damage = 50;
    public List<GameObject> EnemyList;
    public GameObject fireball;
    public GameObject fireArea;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > shootSpeed)
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
                        //make fire area
                        IEnemy enemyInterface = enemy.GetComponent<IEnemy>();
                        Instantiate(fireArea, enemy.transform.position, enemy.transform.rotation);

                        //throw fireball towards the fire area
                        GameObject SpawnedFIREBALL = Instantiate(fireball, this.gameObject.transform);
                        ShootSpeer script = SpawnedFIREBALL.GetComponent<ShootSpeer>();
                        SpawnedFIREBALL.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                        script.objectToHit = enemy.transform;

                        //damage enemy
                        enemyInterface.Kill(damage);
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
        GameObject EnemyOBJ = EnemyList.FirstOrDefault(enemy => enemy.name == EnemeyName);
        EnemyList.Remove(EnemyOBJ);

    }
}
