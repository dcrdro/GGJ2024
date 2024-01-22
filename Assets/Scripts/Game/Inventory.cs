using System;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public ResourceType type;
    public int count = 1;
}

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public event Action<Item> Added;
    public event Action<Item> Updated;
    public event Action<Item> Removed;

    public void Add(ResourceType type)
    {
        var item = items.Find(x => x.type == type);
        if (item != null)
        {
            item.count++;
            Updated?.Invoke(item);
        }
        else
        {
            item = new Item() { type = type };
            items.Add(item);
            Added?.Invoke(item);
        }
    }

    public void Remove(ResourceType type, int count)
    {
        var item = items.Find(x => x.type == type);
        if (item != null)
        {
            item.count -= count;
            if (item.count <= 0)
            {
                Remove(item);
            }
            else Updated?.Invoke(item);
        }
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        Removed?.Invoke(item);
    }

    public bool Has(ResourceType type, int count = 1)
    {
        return items.Find(x => x.type == type && x.count >= count) != null;
    }
}