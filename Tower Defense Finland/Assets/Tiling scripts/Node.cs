using UnityEngine;

public class Node : MonoBehaviour
{
    [Header("Hover")]
    private Color hoverColor = Color.yellowNice;
    private Renderer rend;
    private Color startColor;

    [Header("Building")]
    [SerializeField] private bool BuiltIn = false;
    private BuildManager buildManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = GameObject.Find("GameManager").GetComponent<BuildManager>();
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
        Instantiate(buildManager.objectToBuild(), this.transform.position, this.transform.rotation);
        BuiltIn = true;
    }
}
