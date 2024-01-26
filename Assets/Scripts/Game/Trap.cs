using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public string AnimationParameter;

    private void OnTriggerEnter(Collider other)
    {
        // rework on type
        if (other.TryGetComponent<EnemySharedState>(out var state))
        {
            // catch
            // implement enemy logic

            state.Jewel.Drop();
            state.Jewel = null; 
            Destroy(gameObject);
        }
    }
}
