using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerUpgradeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public enum UpgradeTypes
    {
        SpeedAttack,
        DamageIncrease
    }

    public GameObject parentObject;

    [SerializeField] public UpgradeTypes upgradeTypes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentObject = GetComponentInParent<EventClick>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
    virtual public void OnPointerClick(PointerEventData eventData)
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
