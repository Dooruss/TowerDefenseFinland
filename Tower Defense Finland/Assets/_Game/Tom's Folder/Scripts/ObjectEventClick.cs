using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectEventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private List<GameObject> Towers;

    private GameObject parentObject;

    private void Start()
    {
        parentObject = GetComponentInParent<EventClick>().gameObject;
    }

    private enum TowerTypes
    {
        Tower1,
        Tower2,
        Tower3
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
            case TowerTypes.Tower1:
                Destroy(parentObject);
                Instantiate(Towers[0].gameObject, new Vector3(parentObject.transform.position.x, parentObject.transform.position.y, parentObject.transform.position.z), Quaternion.identity);
                Debug.Log("Boop");
                break;

            case TowerTypes.Tower2:
                Destroy(parentObject);
                Instantiate(Towers[1].gameObject, new Vector3(parentObject.transform.position.x, parentObject.transform.position.y, parentObject.transform.position.z), Quaternion.identity);
                Debug.Log("Boop");
                break;

            case TowerTypes.Tower3:
                Destroy(parentObject);
                Instantiate(Towers[2].gameObject, new Vector3(parentObject.transform.position.x, parentObject.transform.position.y, parentObject.transform.position.z), Quaternion.identity);
                Debug.Log("Boop");
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
