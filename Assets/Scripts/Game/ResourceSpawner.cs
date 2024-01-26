using EnemyLogic;
using EnemyLogic.UI;
using JewelLogic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResourceSpawner : MonoBehaviour
{
    public ResourceType ResourceType;
    public float interval;
    public int maxCount;
    public ResourcesDatabase resourcesDatabase;
    public Timer timer;

    public Text countText;
    public ActionProgressBar progressBar;
    public Image icon;

    private Resoure resource;  

    // Use this for initialization
    IEnumerator Start()
    {
        icon.sprite = resourcesDatabase[ResourceType].icon;

        progressBar.Toggle(true);
        while (true)
        {
            var data = resourcesDatabase[ResourceType];
            if (resource == null)
            {
                Debug.Log("spawn: " + data.resourceType, this);
                resource = Instantiate(data.prefab, transform.position, Quaternion.identity);
                resource.resourceType = ResourceType;
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

            timer.Play(interval, null, () => progressBar.SetValue(timer.NormalizedTime));

            yield return new WaitUntil(timer.IsTimeExceeded);
            
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 1f);
    }
}
