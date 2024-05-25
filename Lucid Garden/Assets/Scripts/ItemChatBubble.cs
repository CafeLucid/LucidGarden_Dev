using System;
using UnityEngine;

public class ItemChatBubble : MonoBehaviour
{
    public Action<ItemSO> OnDropItem;
    public SpriteRenderer itemImage;
    public bool isActive;
    public Action OnHappen;
    public void Show()
    {
        isActive = true;
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        isActive = false;
        OnHappen?.Invoke();
        gameObject.SetActive(false);
    }
    public void DropItem(ItemSO dropItem)
    {
        if (dropItem == null) return;
        Debug.Log("ItemChatBubbleDrop");
        OnDropItem?.Invoke(dropItem);
        Hide();
    }
}
