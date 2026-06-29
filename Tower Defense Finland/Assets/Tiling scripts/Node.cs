using UnityEngine;
using static BuildManager;

public class Node : MonoBehaviour
{
    [Header("Hover")]
    private Color hoverColor = Color.aliceBlue;
    private Renderer rend;
    private Color startColor;

    [Header("Building")]
    [SerializeField] private bool BuiltIn = false;
    private BuildManager buildManager;
    [SerializeField]  float TowerLifeTime = 0f;
    [SerializeField] GameObject builtTower;

    [Header("Money")]
    MoneyManager moneyManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = GameObject.Find("GameManager").GetComponent<BuildManager>();
        moneyManager = GameObject.Find("GameManager").GetComponent<MoneyManager>();

    }
    private void Update()
    {

        if (TowerLifeTime > 0f)
        {
            Debug.Log(TowerLifeTime);
            TowerLifeTime -= Time.deltaTime;
        }

        if (TowerLifeTime < 0f && builtTower != null)
        {
            Debug.Log("Delete plz");
            Destroy(builtTower);
            BuiltIn = false;
        }

    }
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (BuiltIn)
        {
            Debug.Log("You have allready built here");
            return;
        }
        Debug.Log("Buildinggg");
        if (buildManager.objectToBuild() != null)
        {
            builtTower = Instantiate(buildManager.objectToBuild(), new Vector3(this.transform.position.x, 2f, this.transform.position.z), Quaternion.identity);
           
                switch (buildManager.TowerToBuild)
                {
                    case ToBuild.ThorTower:
                    moneyManager.ThorTowers--;
                    TowerLifeTime = moneyManager.ThorTowerLiftetime;
                        break;
                    case ToBuild.FireTower:
                    moneyManager.FireTowers--;
                    TowerLifeTime = moneyManager.FireTowerLifeTime;
                        break;
                    case ToBuild.AOEtower:
                    moneyManager.AOEtowers--;
                    TowerLifeTime = moneyManager.AOETowerLifeTime;
                    break;
                }
            BuiltIn = true;
        }
        
    }
}
