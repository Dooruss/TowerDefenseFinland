using System;
using UnityEngine;
using UnityEngine.UI;

public class MainTower : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    [SerializeField] public float MainCurrentHealth;
    [SerializeField] private Image HP_Bar;

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
        HP_Bar.fillAmount = MainCurrentHealth / MaxHealth;
    }
}
