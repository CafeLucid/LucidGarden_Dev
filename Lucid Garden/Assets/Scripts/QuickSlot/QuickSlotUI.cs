using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class QuickSlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject quickSlotUI;
    public TextMeshProUGUI[] itemCounts;
    public List<QuickSlotItem> itemPrefabs = new List<QuickSlotItem>();

    private GameObject draggingItem;
    private RectTransform draggingPlane;


    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 시작 시 아이템 아이콘을 생성
        int slotIndex = transform.GetSiblingIndex();
        draggingItem = Instantiate(itemPrefabs[slotIndex + 1].itemPrefab, transform);
        draggingItem.transform.SetAsLastSibling();
        draggingPlane = transform as RectTransform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggingItem != null)
        {
            SetDraggedPosition(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggingItem != null)
        {
            Destroy(draggingItem);
            if (eventData.pointerEnter != null)
            {
                //말풍선에 드래그
            }
        }
    }

    private void SetDraggedPosition(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingPlane, eventData.position, eventData.pressEventCamera, out Vector3 globalMousePos))
        {
            draggingItem.transform.position = globalMousePos;
        }
    }
}

