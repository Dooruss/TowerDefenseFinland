using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int Money;

    public int ThorTowers = 0;
    public int FireTowers = 0;
    public int AOEtowers = 0;

    [SerializeField] TextMeshProUGUI ThorTowerText;
    [SerializeField] TextMeshProUGUI FireTowerText;
    [SerializeField] TextMeshProUGUI AOEtowText;

    private void Update()
    {
        ThorTowerText.text = ThorTowers.ToString();
        FireTowerText.text = FireTowers.ToString();
        AOEtowText.text = AOEtowers.ToString();
    }

    public void BuyThorTower()
    {
        ThorTowers++; 
    }
    public void BuyFireTower()
    {
        FireTowers++;
    }

    public void BuyAOEtow()
    {
        AOEtowers++;
    }
}
