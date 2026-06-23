using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectEventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private List<GameObject> Towers;

    [SerializeField] private GameObject parentObject;

    [SerializeField] private TowerPrice towerPrice;

    private enum TowerTypes
    {
        ThorTower,
        FireTower,
        AreaTower
    }

    [SerializeField] private TowerTypes towerTypes;

    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (towerTypes)
        {
            case TowerTypes.ThorTower:
                Instantiate(Towers[0].gameObject, new Vector3(parentObject.transform.position.x, parentObject.transform.position.y + 5, parentObject.transform.position.z), Quaternion.Euler(parentObject.GetComponent<EventClick>().TowerRotation));
                Destroy(GetComponentInParent<Canvas>().gameObject);
                MainTower.instance.money -= towerPrice.thorTowerPrice;
                break;

            case TowerTypes.AreaTower:
                Instantiate(Towers[1].gameObject, new Vector3(parentObject.transform.position.x, parentObject.transform.position.y + 5.5f, parentObject.transform.position.z), Quaternion.Euler(parentObject.GetComponent<EventClick>().TowerRotation));
                Destroy(GetComponentInParent<Canvas>().gameObject);
                MainTower.instance.money -= towerPrice.fireTowerPrice;
                break;

            case TowerTypes.FireTower:
                Instantiate(Towers[2].gameObject, new Vector3(parentObject.transform.position.x, parentObject.transform.position.y + 5.5f, parentObject.transform.position.z), Quaternion.Euler(parentObject.GetComponent<EventClick>().TowerRotation));
                Destroy(parentObject);
                Destroy(GetComponentInParent<Canvas>().gameObject);
                MainTower.instance.money -= towerPrice.areaTowerPrice;
                break;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //GetComponent<MeshRenderer>().material = highLightedObject;
        if(gameObject.tag == "Tower Buttons")
        {
            gameObject.GetComponent<Outline>().enabled = true;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //GetComponent<MeshRenderer>().material = null;
        if (gameObject.tag == "Tower Buttons")
        {
            gameObject.GetComponent<Outline>().enabled = false;
        }
    }
}
