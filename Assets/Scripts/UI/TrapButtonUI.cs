using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TrapButtonUI : MonoBehaviour
{
    public Button button;
    public Text title;
    public Image icon;
    public ItemUI itemUIPrefab;

    public Transform reqsHolder;

    public TrapType Type { get; set; }

    public event Action<TrapButtonUI> Used;

    public void SetTitle(string t) => title.text = t;
    public void SetIcon(Sprite s) => icon.sprite = s;
    public void SetEnabled(bool on) => button.interactable = on;
    public void SetRequirements(ResourceRequirement[] reqs, ResourcesDatabase resourcesDatabase)
    {
        foreach (ResourceRequirement req in reqs)
        {
            var ui = Instantiate(itemUIPrefab, reqsHolder);
            var data = resourcesDatabase[req.type];
            ui.SetTitle(data.name);
            ui.SetCount(req.count);
            ui.SetIcon(data.icon);
        }
    }
    public void Use()  => Used?.Invoke(this);
}
