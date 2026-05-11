using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Material highLightedObject;

    private enum TowerTypes
    {
        Tower1,
        Tower2,
        Tower3
    }

    [SerializeField] private TowerTypes towerTypes;

    [SerializeField] private List<GameObject> Towers;

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
            case TowerTypes.Tower1:
                Destroy(gameObject);
                Instantiate(Towers[0].gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                break;

            case TowerTypes.Tower2:
                Destroy(gameObject);
                Instantiate(Towers[1].gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                break;

            case TowerTypes.Tower3:
                Destroy(gameObject);
                Instantiate(Towers[2].gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                break;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<MeshRenderer>().material = highLightedObject;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<MeshRenderer>().material = null;
    }
}
