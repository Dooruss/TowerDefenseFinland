using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject ThorTower;
    public GameObject FireTower;
    public GameObject AOEtower;

    public enum ToBuild
    {   None,
        ThorTower,
        FireTower,
        AOEtower
    }

    public ToBuild TowerToBuild;

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
}
