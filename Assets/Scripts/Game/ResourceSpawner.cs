using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResourceSpawner : MonoBehaviour
{
    public ResourceType ResourceType;
    public float interval;
    public int maxCount;
    public ResourcesDatabase resourcesDatabase;

    public Text countText;

    private Resoure resource;  

    // Use this for initialization
    IEnumerator Start()
    {
        while (true)
        {
            var data = resourcesDatabase[ResourceType];
            if (resource == null)
            {
                resource = Instantiate(data.prefab, transform.position, Quaternion.identity);
                resource.Collected += () =>
                {
                    countText.text = $"x0";
                    resource = null;
                };

            }
            else
            {
                resource.Count++;
            }
            countText.text = $"x{resource.Count}";
            
            
            yield return new WaitUntil(() => resource == null || resource.Count < maxCount);
            yield return new WaitForSeconds(interval);
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 1f);
    }
}
