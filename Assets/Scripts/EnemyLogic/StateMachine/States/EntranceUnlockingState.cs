using HouseLogic.Entrances;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class EntranceUnlockingState : ExitableStateBase, IPayloadedState<EntranceBase>
  {
    [SerializeField, HideInInspector]
    private EnemyStateMachine _stateMachine;

    public void Enter(EntranceBase entrance)
    {
      if (entrance.IsUnlocked)
      {
        // NEED TO DEVELOP: play animation or place enemy inside house and after switch state;
        _stateMachine.Enter<MoveToJewelState>();
        return;
      }
      
      entrance.StartUnlocking();
      
      // NEED TO DEVELOP: NEED TO WAIT BEFORE UNLOCK
      entrance.Unlock();
      _stateMachine.Enter<MoveToJewelState>();
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