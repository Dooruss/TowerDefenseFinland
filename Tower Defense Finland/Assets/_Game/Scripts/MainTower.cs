using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainTower : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float MaxHealth;
    [SerializeField] public float MainCurrentHealth;
    [Header("UI Elements")]
    [SerializeField] private Image HP_Bar;
    [SerializeField] private TextMeshProUGUI Text_HP_Amount;
    [SerializeField] private GameObject FailureUI;

    private void Start()
    {
        MainCurrentHealth = MaxHealth;
    }
    void Update()
    {
        if (MainCurrentHealth <= 0) { GameOver(); }
        HP_Bar.fillAmount = MainCurrentHealth / MaxHealth;
        Text_HP_Amount.text = $"{MainCurrentHealth}/{MaxHealth}";
    }

    void GameOver()
    {
        //game overr-
        Scene_Manager.PauseGame();
        FailureUI.SetActive(true);
    }
}
