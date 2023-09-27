using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Events : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Mouse Clicked the Button");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Mouse Pointer Down");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Pointer Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Pointer Exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Mouse Pointer Up");
    }
}
