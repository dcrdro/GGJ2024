using JewelLogic;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class JewelPickUpState : ExitableStateBase, IPayloadedState<Jewel>
  {
    [SerializeField, HideInInspector]
    private EnemyStateMachine _stateMachine;

    public void Enter(Jewel jewel)
    {
      jewel.PickUp();
      _stateMachine.Enter<EscapeFromHouseState>();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
      if (_stateMachine == null)
        TryGetComponent(out _stateMachine);
    }
#endif
  }
}