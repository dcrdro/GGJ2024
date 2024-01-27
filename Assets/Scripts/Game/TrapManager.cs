using System.Collections;
using System.Linq;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public TrapDatabase trapDatabase;
    public ResourcesDatabase resourcesDatabase;
    public Inventory inventory;

    public TrapManagerUI ui;

    void Start()
    {
        inventory.Added += Inventory_Added;
        inventory.Updated += Inventory_Updated;
        inventory.Removed += Inventory_Removed;

        foreach (var trap in trapDatabase.traps)
        {
            ui.CreateButton(trap, resourcesDatabase);
        }
        ui.UpdateEnableStatus();
    }

    private void Inventory_Updated(Item item)
    {
        ui.UpdateEnableStatus();
    }

    private void Inventory_Removed(Item item)
    {
        ui.UpdateEnableStatus();
    }

    private void Inventory_Added(Item item)
    {
        ui.UpdateEnableStatus();
    }

    public bool IsTrapCreatable(TrapType trap)
    {
        var data = trapDatabase[trap];
        return data.requiredResources.All(item => inventory.Has(item.type, item.count));

    }

    public void Use(TrapType trap)
    {
        Debug.Log("used " + trap);
        var prefab = trapDatabase[trap].prefab;
        var player = FindObjectOfType<Player>();
        var obj = Instantiate(prefab, player.transform.position, Quaternion.identity);
        obj.TrapType = trap;
        FindObjectOfType<AudioManager>().PlayTrapPlace();


        foreach (var req in trapDatabase[trap].requiredResources)
        {
            inventory.Remove(req.type, req.count);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnDestroy()
    {
        inventory.Added -= Inventory_Added;
        inventory.Removed -= Inventory_Removed;
        inventory.Updated -= Inventory_Updated;
    }
}
