using UnityEngine;
using UnityEngine.UI;
using System;

public class DragSlot : MonoBehaviour
{
    static public DragSlot instance;
    public QuickSlotItem dragSlot;
    public ItemSO itemData;
    public bool isDragging = false;

    [SerializeField]
    private Image itemImage;

    private void Awake()
    {
        instance = this;
        SetColor(0);
    }

    public void DragSetImage(Sprite _itemImage)
    {
        itemImage.sprite = _itemImage;
        SetColor(1);
    }

    public void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
}
