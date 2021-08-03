using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Canvas canvas;

    public GameObject floor;
    RectTransform rectTransform;
    RectTransform floorRectTransform;
    //Vector3 positionIntoFloor;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        floorRectTransform = floor.GetComponent<RectTransform>();

        //positionIntoFloor = new Vector3(0.2f, -0.4f, 0f);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform.SetParent(canvas.transform);
        rectTransform.position.Set(0, 0, 0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        rectTransform.anchoredPosition = floorRectTransform.anchoredPosition;

        rectTransform.SetParent(floor.transform);
        //rectTransform.position.Set(0, 0, 0);
        //rectTransform.position = new Vector3(1, 1, 1);
    }
}
