using Extensions;
using HouseLogic.Entrances;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class MoveToHouseExitState : ExitableStateBase, IState
  {
    [SerializeField, HideInInspector]
    private EnemyMovement _movement;

    [SerializeField, HideInInspector]
    private EnemyStateMachine _stateMachine;

    #region Fields

    private EntranceBase _targetEntrance;

    #endregion
    
    public void Enter()
    {
      _targetEntrance = NavMeshExtensions.FindClosestEntrance(transform.position, false);
      
      _movement.SetTarget(_targetEntrance.OutsidePoint);
      _movement.ToggleMovement(true);
      
      _movement.OnTargetReached += OnEntranceReached;
    }

    public override void Exit()
    {
      base.Exit();
      
      _movement.ToggleMovement(false);
      _movement.OnTargetReached -= OnEntranceReached;
    }

    private void OnEntranceReached() => 
      _stateMachine.Enter<EntranceUnlockingState, EntranceBase>(_targetEntrance);

#if UNITY_EDITOR
    private void OnValidate()
    {
      if (_movement == null)
        TryGetComponent(out _movement);

      if (_stateMachine == null)
        TryGetComponent(out _stateMachine);
    }
#endif
  }
}