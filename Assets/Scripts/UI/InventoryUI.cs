using System.Collections;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public ResourcesDatabase resourcesDatabase;

    public ItemUI itemPrefab;

    // Use this for initialization
    void Start()
    {
        inventory.Added += Inventory_Added;
        inventory.Updated += Inventory_Updated;
        inventory.Removed += Inventory_Removed;

        foreach (var item in resourcesDatabase.resources)
        {
            var ui = Instantiate(itemPrefab, transform.GetChild(0));
            ui.Type = item.resourceType;
            ui.SetCount(0);
            ui.SetTitle(item.name);
            ui.SetIcon(item.icon);
        }
    }

    private void Inventory_Updated(Item item)
    {
        var ui = transform.GetComponentsInChildren<ItemUI>().FirstOrDefault(i => i.Type == item.type);
        ui.SetCount(item.count);
    }

    private void Inventory_Removed(Item item)
    {
        var ui = transform.GetComponentsInChildren<ItemUI>().FirstOrDefault(i => i.Type == item.type);
        ui.SetCount(0);
    }

    void OnDestroy()
    {
        inventory.Added -= Inventory_Added;
        inventory.Removed -= Inventory_Removed;
        inventory.Updated -= Inventory_Updated;
    }

    private void Inventory_Added(Item item)
    {
        var data = resourcesDatabase[item.type];
        var ui = transform.GetComponentsInChildren<ItemUI>().FirstOrDefault(i => i.Type == item.type);
        if (ui)
        {
            ui.SetCount(item.count);
        }
        else
        {
            ui = Instantiate(itemPrefab, transform.GetChild(0));
            ui.Type = item.type;
            ui.SetCount(item.count);
            ui.SetTitle(data.name);
            ui.SetIcon(data.icon);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
