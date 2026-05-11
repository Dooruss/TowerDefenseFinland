using UnityEngine;

public class MainTower : MonoBehaviour
{
    [SerializeField] private int MaxHealth;
    [SerializeField] public int MainCurrentHealth;

    private void Start()
    {
        MainCurrentHealth = MaxHealth;
    }
    void Update()
    {
        if (MainCurrentHealth <= 0)
        {
            //game over
        }
    }
}
