using System;
using UnityEngine;

public class Resoure : MonoBehaviour
{
    public ResourceType resourceType;

    public int Count { get; set; } = 1;

    public event Action Collected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var inv))
        {
            Collected?.Invoke();
            FindObjectOfType<Inventory>().Add(resourceType, Count);
            Destroy(gameObject);
        }
    }
}