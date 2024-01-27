using Extensions;
using JewelLogic;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class MoveToJewelState : ExitableStateBase, IState
  {
    [SerializeField, HideInInspector]
    private EnemyMovement _movement;

    [SerializeField, HideInInspector]
    private EnemyStateMachine _stateMachine;

    #region Fields

    private Jewel _currentJewel;

    #endregion
    
    public void Enter()
    {
      FindTarget();

      _movement.OnTargetReached += OnReachedJewel;
      _currentJewel.OnStartPickingUp += FindTarget;
    }

    public override void Exit()
    {
      base.Exit();
      
      _movement.ToggleMovement(false);
      _movement.OnTargetReached -= OnReachedJewel;
      _currentJewel.OnStartPickingUp -= FindTarget;
    }

    private void FindTarget()
    {
      _currentJewel = NavMeshExtensions.FindClosestJewel(transform.position);
      
      _movement.ToggleMovement(true);
      _movement.SetTarget(_currentJewel.Position);
    }

    private void OnReachedJewel() => 
      _stateMachine.Enter<JewelPickUpState, Jewel>(_currentJewel);

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