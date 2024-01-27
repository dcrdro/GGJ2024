using System;
using UnityEngine;

[Serializable]
public class ResourceRequirement
{
    public ResourceType type;
    public int count;
}

[CreateAssetMenu]
public class TrapData : ScriptableObject
{
    public string name;
    public TrapType trapType;
    public ResourceRequirement[] requiredResources;
    public Sprite icon;
    public Trap prefab;
}