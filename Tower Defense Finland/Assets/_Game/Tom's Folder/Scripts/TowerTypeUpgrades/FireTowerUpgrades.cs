using UnityEngine;
using UnityEngine.EventSystems;

public class FireTowerUpgrades : TowerUpgradeButton
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        switch (upgradeTypes)
        {
            case UpgradeTypes.SpeedAttack:
                GetComponentInChildren<FireTower>().shootSpeed -= 0.5f;
                Debug.Log("Boop");
                break;

            case UpgradeTypes.DamageIncrease:

                GetComponentInChildren<FireTower>().damage += 5;
                Debug.Log("Boop");
                break;
        }
    }
}
