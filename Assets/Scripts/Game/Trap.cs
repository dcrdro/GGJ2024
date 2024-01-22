using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public string AnimationParameter;

    private void OnTriggerEnter(Collider other)
    {
        // rework on type
        if (other.name.Contains("Enemy"))
        {
            // catch
            Destroy(gameObject);
        }
    }
}
