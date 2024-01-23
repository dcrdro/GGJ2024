using JewelLogic;
using UnityEngine;

namespace EnemyLogic.States
{
  public class JewelPickUpState : StateBase, IPayloadedState<Jewel>
  {
    [SerializeField, HideInInspector]
    private EnemyStateMachine _stateMachine;

    public void Enter(Jewel jewel)
    {
      jewel.PickUp();
      _stateMachine.Enter<EscapeFromHouseState>();
    }

    public void Exit()
    {
      
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