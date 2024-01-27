using EnemyLogic.StateMachine;
using EnemyLogic.StateMachine.States;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    public string AnimationParameter;
    public float animationTime;

    public Image icon;

    public TrapType TrapType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent(out EnemyStateMachine stateMachine))
        {
            // FindObjectOfType<AudioManager>().PlayTrapCatch();

            switch (TrapType)
            {
                case TrapType._TestTrap1:
                    break;
                case TrapType.Fire:
                    stateMachine.Enter<FireTrapState>();
                    break;
                case TrapType.Ice:
                    stateMachine.Enter<IceTrapState>();
                    break;
                case TrapType.Cage:
                    stateMachine.Enter<CageTrapState>();
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
