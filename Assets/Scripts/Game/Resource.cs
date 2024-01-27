using System;
using UnityEngine;

public class Resoure : MonoBehaviour
{
    public float rotSpeed;
    public float swaySpeed;
    public float swayDist;
    public ResourceType resourceType { get; set; }

    public int Count { get; set; } = 1;

    public event Action Collected;

    private Vector3 initPos;

    private void Awake()
    {
        initPos = transform.position;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
        var sway = Mathf.Sin(Time.time * swaySpeed) * swayDist;
        transform.position = initPos + transform.up * sway;
    }

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