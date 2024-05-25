using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChatBubble : MonoBehaviour
{
    public Action<ItemSO> OnDropItem;
    public SpriteRenderer itemImage;
    public bool isActive;

    private void Start()
    {
        DragSlot.instance.DropItem += DropItem;
    }
    public void Show()
    {
        isActive = true;
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        isActive = false;
        gameObject.SetActive(false);
    }
    public void DropItem(ItemSO dropItem)
    {
        if (dropItem == null) return;
        OnDropItem?.Invoke(dropItem);
        Hide();
    }
}
