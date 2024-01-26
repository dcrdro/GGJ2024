using HouseLogic.Entrances;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public abstract class MoveToHouseEntranceState : ExitableStateBase, IState
  {
    [SerializeField, HideInInspector]
    private EnemyMovement _movement;

    [SerializeField, HideInInspector]
    private EnemyStateMachine _stateMachine;

    #region Properties

    protected EnemyStateMachine StateMachine => _stateMachine;
    protected EntranceBase TargetEntrance => _targetEntrance;

    #endregion
    
    #region Fields

    private EntranceBase _targetEntrance;

    #endregion

    protected abstract EntranceBase GetTargetEntrance();
    protected abstract void OnEntranceReached();
    protected abstract Vector3 GetTargetPosition();
    
    public void Enter()
    {
      _targetEntrance = GetTargetEntrance();
      
      _movement.SetTarget(GetTargetPosition());
      _movement.ToggleMovement(true);
      
      _movement.OnTargetReached += OnEntranceReached;
    }

    public override void Exit()
    {
      base.Exit();
      
      _movement.ToggleMovement(false);
      _movement.OnTargetReached -= OnEntranceReached;
    }

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