using EnemyLogic.StateMachine;
using EnemyLogic.StateMachine.States;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public string AnimationParameter;
    public float animationTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent(out EnemyStateMachine stateMachine))
        {
            // FindObjectOfType<AudioManager>().PlayTrapCatch();
            stateMachine.Enter<FireTrapState>();
            Destroy(gameObject);
        }
    }
}
