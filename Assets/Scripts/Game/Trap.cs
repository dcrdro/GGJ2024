using JewelLogic;
using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public string AnimationParameter;
    public float animationTime;

    private void OnTriggerEnter(Collider other)
    {
        // rework on type
        var enemy = other.GetComponentInParent<EnemySharedState>();
        if (enemy != null)
        {
            // catch
            // implement enemy logic

            FindObjectOfType<AudioManager>().PlayTrapCatch();

            enemy.Jewel?.Drop();
            enemy.Jewel = null;
            enemy.StartCoroutine(ShowCamera(enemy));
            Destroy(gameObject);
        }
    }

    // todo : do in separate enemy state
    private IEnumerator ShowCamera(EnemySharedState state)
    {
        FindObjectOfType<UIManager>().trapRender.SetActive(true);
        state.TrapCamera.enabled = true;
        yield return new WaitForSeconds(animationTime);
        state.TrapCamera.enabled = false;
        FindObjectOfType<UIManager>().trapRender.SetActive(false);
    }
}
