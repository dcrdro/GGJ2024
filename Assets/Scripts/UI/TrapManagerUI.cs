using System.Collections.Generic;
using UnityEngine;

public class TrapManagerUI : MonoBehaviour
{
    public TrapManager trapManager;
    public TrapButtonUI trapButtonUIPrefab;

    public List<TrapButtonUI> trapButtons = new List<TrapButtonUI>();

    public void CreateButton(TrapData trapData, ResourcesDatabase resourcesDatabase)
    {
        var ui = Instantiate(trapButtonUIPrefab, transform);
        
        ui.SetTitle(trapData.name);
        ui.SetIcon(trapData.icon);
        ui.Type = trapData.trapType;
        ui.SetRequirements(trapData.requiredResources, resourcesDatabase);
        ui.Used += OnUsed;

        trapButtons.Add(ui);
    }

    public void UpdateEnableStatus()
    {
        foreach (var trapButton in trapButtons)
        {
            var on = trapManager.IsTrapCreatable(trapButton.Type);
            trapButton.SetEnabled(on);
        }
    }

    private void OnUsed(TrapButtonUI button)
    {
        trapManager.Use(button.Type);
    }
}
