using UnityEngine;

public class HurtMainTower : MonoBehaviour
{
    [SerializeField] TilingGameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("Hurt main tower");
            gameManager.Health -= 5f;
            Destroy(other.gameObject);
        }
    }
}
