using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectEventClick : MonoBehaviour
{
    [SerializeField] private Material highLightedObject;

    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {

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
