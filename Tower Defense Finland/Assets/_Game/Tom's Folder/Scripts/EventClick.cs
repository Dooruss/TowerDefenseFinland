using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Material highLightedObject;

    private bool ObjectClicked;
     
    [SerializeField] private List<GameObject> Buttons;

    
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
        }
    }

    public void ClickTower()
    {
            for (int i = 0; i < Buttons.Count; i++)
            {
                Buttons[i].gameObject.SetActive(true);
            }
                TouchDetection.instance.CurrentTower = gameObject;
                ObjectClicked = true;
        Debug.Log("work");
    }
    public void ExitTower()
    {
        GetComponent<MeshRenderer>().material = null;
        ObjectClicked = false;
        TouchDetection.instance.CurrentTower = null;
        for (int i = 0; i < Buttons.Count; i++)
        {
            Buttons[i].gameObject.SetActive(false);
        }
    }

    public void DestroyTower()
    {
        for (int i = 0; i < Buttons.Count; i++)
        {
            Destroy(Buttons[i]);
        }
    }
}
