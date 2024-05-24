using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSet : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();
    public ItemSO GetItem(int itemID)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == itemID) { return items[i]; }
        }
        return null;
    }
}
