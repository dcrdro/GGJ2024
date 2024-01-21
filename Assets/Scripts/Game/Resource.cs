using UnityEngine;

public enum ResourceType
{
    _Test1,
    _Test2,
}

public class Resoure : MonoBehaviour
{
    public ResourceType resourceType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Inventory>(out var inv))
        {
            inv.Add(resourceType);
            Destroy(gameObject);
        }
    }
}