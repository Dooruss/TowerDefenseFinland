using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] public Vector3 boxSize = new Vector3(5, 5, 5); 
    public bool explode = false;
    public bool exploded = false;
    private bool hasExploded = false;
    public float timer;
    public int BombDamage = 10;
    [SerializeField] ParticleSystem particles;


    //if explode is true
    //explode and hit all enemies in radius


    private void Update()
    {
        timer += Time.deltaTime;
        if (exploded == true && timer > 2f)
        {
            Destroy(this.gameObject);
        }
        else if (explode && exploded == false)
        {
            CheckCollisions();
            particles.Play();
            exploded = true;
        }

        else if (explode == false && timer > 1f)
        {
            explode = true;
            timer = 0;

        }


    }

    
    public void CheckCollisions()
    {
        //make a list called hits that checks for triggers and other colliders with the tag enemy 
        Collider[] hits = Physics.OverlapBox(
            transform.position,
            boxSize / 2,
            Quaternion.identity,
            ~0, // Use all layers (or specify your own LayerMask)
            QueryTriggerInteraction.Collide // This includes triggers!
        );

        foreach (var hit in hits)
        {
            //here you check for the enemy script
            RunningEnemy tillingEnemy = hit.GetComponent<RunningEnemy>();
            if (tillingEnemy != null)
            {
                tillingEnemy.currentHealth -= BombDamage;
                tillingEnemy.UpdateHealthBar();
            }
            Enemy_1 enemyScipt = hit.GetComponent<Enemy_1>();
            if (enemyScipt != null)
            {
                enemyScipt.CurrentHealth -= BombDamage;
                Debug.Log(enemyScipt.gameObject.name + "was hit");
            }
        }
        

    }
}

