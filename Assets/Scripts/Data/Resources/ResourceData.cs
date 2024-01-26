using UnityEngine;

[CreateAssetMenu]
public class ResourceData : ScriptableObject
{
    public string name;
    public ResourceType resourceType;
    public Sprite icon;
    public Resoure prefab;
}