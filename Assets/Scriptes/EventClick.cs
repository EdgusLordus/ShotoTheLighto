using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Materialchange materialChange;

    private void Awake()
    {
        materialChange = GetComponent<Materialchange>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Empty
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Empty
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Empty
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Empty
    }
}
