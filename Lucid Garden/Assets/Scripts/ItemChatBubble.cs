using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChatBubble : MonoBehaviour
{
    public Action<ItemSO> OnDropItem;
    public SpriteRenderer itemImage;
    private void Start()
    {
        DragSlot.instance.DropItem += DropItem;
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void DropItem(ItemSO dropItem)
    {
        if (dropItem == null) return;
        OnDropItem?.Invoke(dropItem);
        Hide();
    }
}
