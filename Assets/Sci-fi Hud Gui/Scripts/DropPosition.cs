using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropPosition : MonoBehaviour, IDropHandler
{
    private Image _thisImage;
    [SerializeField] private string[] validImageNames;

    public void OnDrop(PointerEventData eventData)
    {
        string draggedImageName = eventData.pointerDrag.name;

        // Check if the dragged image is in the list of valid image names
        foreach (var validName in validImageNames)
        {
            if (draggedImageName == validName)
            {
                eventData.pointerDrag.GetComponent<Dragable>().SetNewPosition(_thisImage.rectTransform.localPosition);
                return;
            }
        }
    }

    void Start()
    {
        _thisImage = GetComponent<Image>();
    }
}
