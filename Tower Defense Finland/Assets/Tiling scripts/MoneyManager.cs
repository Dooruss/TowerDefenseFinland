using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int Money = 300;

    public int ThorTowers = 0;
    public int FireTowers = 0;
    public int AOEtowers = 0;

    private int ThorTowerPrice = 100;
    private int FireTowerPrice = 100;
    private int AOEtowerPrice = 100;

    [SerializeField] TextMeshProUGUI ThorTowerText;
    [SerializeField] TextMeshProUGUI FireTowerText;
    [SerializeField] TextMeshProUGUI AOEtowText;

    [SerializeField] TextMeshProUGUI moneyText;

    public float ThorTowerLiftetime = 10f;
    public float FireTowerLifeTime = 5f;
    public float AOETowerLifeTime = 7f;

   
    private void Update()
    {
        ThorTowerText.text = ThorTowers.ToString();
        FireTowerText.text = FireTowers.ToString();
        AOEtowText.text = AOEtowers.ToString();
        moneyText.text = Money.ToString();
    }

    public void BuyThorTower()
    {
        if (Money >= ThorTowerPrice)
        {
            ThorTowers++;
            Money -= ThorTowerPrice;
        }
    }
    public void BuyFireTower()
    {
        if (Money >= FireTowerPrice)
        {
            FireTowers++;
            Money -= FireTowerPrice;
        }
    }

    public void BuyAOEtow()
    {
        if (Money >= AOEtowerPrice)
        {
            AOEtowers++;
            Money -= AOEtowerPrice;
        }
    }
}
