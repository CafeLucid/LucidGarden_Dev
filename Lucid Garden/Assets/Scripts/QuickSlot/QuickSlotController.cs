using System.Collections.Generic;
using UnityEngine;

public class QuickSlotController : MonoBehaviour
{
    public QuickSlotUI quickSlotUI;
    public Dictionary<int, int> items = new Dictionary<int, int>();

    public void Awake()
    {
        items.Add(10001, 0);
        items.Add(10002, 0);
        items.Add(10003, 0);
        items.Add(10004, 0);
        items.Add(10005, 0);

        UpdateItemCount();
    }

    public void AddItem(int id, int amount)
    {
        items[id] += amount;
        UpdateItemCount();
    }

    public void RemoveItem(int id, int amount)
    {
        items[id] -= amount;
        if (items[id] < 0)
        {
            items[id] = 0;
        }
        UpdateItemCount();
    }

    public void UseItem(int id)
    {
        if (items.ContainsKey(id))
        {
            items[id]--;
        }
        UpdateItemCount();
    }

    public void UpdateItemCount()
    {
        for (int i = 0; i < quickSlotUI.itemCounts.Length; i++)
        {
            quickSlotUI.itemCounts[i].text = items[10001 + i].ToString();
        }
    }
}
