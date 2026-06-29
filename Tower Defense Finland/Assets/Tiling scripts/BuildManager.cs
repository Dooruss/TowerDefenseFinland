using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject ThorTower;
    public GameObject FireTower;
    public GameObject AOEtower;

    [SerializeField] MoneyManager moneyManager;
    public enum ToBuild
    {
        None,
        ThorTower,
        FireTower,
        AOEtower
    }

    public ToBuild TowerToBuild;

    private void Update()
    {
        if(moneyManager.ThorTowers == 0 && TowerToBuild == ToBuild.ThorTower)
        {
            TowerToBuild = ToBuild.None;
        }
        if(moneyManager.FireTowers == 0 && TowerToBuild == ToBuild.FireTower)
        {
            TowerToBuild = ToBuild.None;
        }
        if(moneyManager.AOEtowers == 0 && TowerToBuild == ToBuild.AOEtower)
        {
            TowerToBuild= ToBuild.None;
        }
    }
    public GameObject objectToBuild()
    {
        switch (TowerToBuild)
        {
            case ToBuild.None:
                return null;
            case ToBuild.ThorTower:
                return ThorTower;
            case ToBuild.FireTower:
                return FireTower;
            case ToBuild.AOEtower:
                return AOEtower;
        }
        return null;

    }

    public void SetState(int tower)
    {
        TowerToBuild = (ToBuild)tower;
        
    }

    public void SetTowerToNone()
    {
        TowerToBuild = ToBuild.None;
    }
}
