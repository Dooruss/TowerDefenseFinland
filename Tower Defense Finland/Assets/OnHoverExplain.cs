using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverExplain : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //[Header("Resize button on hover")]
    //public float SizeDifference = 1.5f;
    //private Vector2 originalSize;
    //private RectTransform rectTransform;

    [SerializeField] GameObject ui;
    [SerializeField] bool StopTime = false;
    
    private void Awake()
    {
        //rectTransform = GetComponent<RectTransform>();
        //originalSize = rectTransform.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //rectTransform.localScale = originalSize * SizeDifference;
        ui.SetActive(true);
        if (StopTime)
        {
            Time.timeScale = 0;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //rectTransform.localScale = originalSize;
        ui.SetActive(false);
        if (StopTime)
        {
            Time.timeScale = 1;
        }
    }
}
