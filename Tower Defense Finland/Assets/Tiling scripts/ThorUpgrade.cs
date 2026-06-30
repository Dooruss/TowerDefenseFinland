using UnityEngine;

public class ThorUpgrade : MonoBehaviour
{
    MoneyManager moneyManager;
    int UpgradePrice = 300;
    [SerializeField] GameObject UpgradeShit;
    [SerializeField] int Level = 0;
    void Start()
    {
        moneyManager = GameObject.Find("GameManager").GetComponent<MoneyManager>();
    }

    void Update()
    {
        if(moneyManager.Money >= UpgradePrice && Level < 3)
        {
            UpgradeShit.SetActive(true);
        }
        else
        {
            UpgradeShit.SetActive(false);
        }
    }

    public void UpgradeThor()
    {
        moneyManager.Money -= UpgradePrice;
        moneyManager.ThorTowerLiftetime += 5f;
        Debug.Log("Thor tower lifetime is now" + moneyManager.ThorTowerLiftetime);
        Level++;
    }

    public void UpgradeFire()
    {
        moneyManager.Money -= UpgradePrice;
        moneyManager.FireTowerLifeTime += 5;
        Debug.Log("Fire tower lifetime is now" + moneyManager.FireTowerLifeTime);
        Level++;
    }

    public void UpgradeAOE()
    {
        moneyManager.Money -= UpgradePrice;
        moneyManager.AOETowerLifeTime += 5;
        Debug.Log("AEO tower lifetime is now " + moneyManager.AOETowerLifeTime);
        Level++;
    }
}
