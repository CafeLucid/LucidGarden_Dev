using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragSlot : MonoBehaviour
{
    static public DragSlot instance;
    public QuickSlotItem dragSlot;
    public ItemSO itemData;
    public bool isDragging = false;

    [SerializeField]
    private Image itemImage;

    void Start()
    {
        instance = this;
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
