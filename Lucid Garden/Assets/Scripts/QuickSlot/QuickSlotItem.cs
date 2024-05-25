using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuickSlotItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public ItemSO itemData;
    
    public Action<ItemSO> DropItem;

    // 마우스 드래그가 시작 됐을 때 발생하는 이벤트
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemData != null)
        {
            DragSlot.instance.isDragging = true;
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragSetImage(itemData.Sprite);
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    // 마우스 드래그 중일 때 계속 발생하는 이벤트
    public void OnDrag(PointerEventData eventData)
    {
        if (itemData != null)
            DragSlot.instance.transform.position = eventData.position;
    }

    // 마우스 드래그가 끝났을 때 발생하는 이벤트
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0f);

        if(hit.collider != null)
        {
            if(hit.collider.GetComponent<Animal>() != null)
            {
                DropItem?.Invoke(itemData);
            }
        }

        DragSlot.instance.SetColor(0);
        DragSlot.instance.dragSlot = null;
        DragSlot.instance.isDragging = false;
    }
}
