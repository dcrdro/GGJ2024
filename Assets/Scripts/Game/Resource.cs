using System;
using UnityEngine;

public class Resoure : MonoBehaviour
{
    public ResourceType resourceType { get; set; }

    public int Count { get; set; } = 1;

    public event Action Collected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var inv))
        {

            Debug.Log("picked up res: " + resourceType);
            FindObjectOfType<AudioManager>().PlayResource();
            Collected?.Invoke();
            FindObjectOfType<Inventory>().Add(resourceType, Count);
            Destroy(gameObject);
        }
    }
}