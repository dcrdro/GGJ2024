using UnityEngine;

public class Resoure : MonoBehaviour
{
    public ResourceType resourceType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var inv))
        {
            FindObjectOfType<Inventory>().Add(resourceType);
            Destroy(gameObject);
        }
    }
}