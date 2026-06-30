using TMPro;
using UnityEngine;

public class ThorUpgrade : MonoBehaviour
{
    MoneyManager moneyManager;
    int UpgradePrice = 300;
    [SerializeField] GameObject UpgradeShit;
    [SerializeField] int Level = 0;
    [SerializeField] TextMeshProUGUI LvlText;
    void Start()
    {
        moneyManager = GameObject.Find("GameManager").GetComponent<MoneyManager>();
        LvlText.text = ("Lvl " + Level.ToString());
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
        Level++;
        LvlText.text = ("Lvl " + Level.ToString());

    }

    public void UpgradeFire()
    {
        moneyManager.Money -= UpgradePrice;
        moneyManager.FireTowerLifeTime += 5;
        Level++;
        LvlText.text = ("Lvl " + Level.ToString());
    }

    public void UpgradeAOE()
    {
        moneyManager.Money -= UpgradePrice;
        moneyManager.AOETowerLifeTime += 5;
        Level++;
        LvlText.text = ("Lvl " + Level.ToString());
    }
}
