using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Material highLightedObject;

    private bool ObjectClicked;
     
    [SerializeField] private List<GameObject> Buttons;

    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {

        if (!ObjectClicked)
        {
            ObjectClicked = true;

            for (int i = 0; i < Buttons.Count; i++)
            {
                Buttons[i].gameObject.SetActive(true);
            }
        }

        if(ObjectClicked && eventData.pointerClick.gameObject != gameObject)
        {
            GetComponent<MeshRenderer>().material = null;
            for (int i = 0; i < Buttons.Count; i++)
            {
                Buttons[i].gameObject.SetActive(false);
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerEnter.gameObject.tag == "Tower")
        {
            GetComponent<MeshRenderer>().material = highLightedObject;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!ObjectClicked)
        {
            GetComponent<MeshRenderer>().material = null;
            Debug.Log("test");
        }
    }
}
