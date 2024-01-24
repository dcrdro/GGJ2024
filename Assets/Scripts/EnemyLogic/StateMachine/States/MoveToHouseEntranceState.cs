using Core;
using Extensions;
using HouseLogic.Entrances;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyLogic.StateMachine.States
{
  public class MoveToHouseEntranceState : ExitableStateBase, IState
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
      _targetEntrance = FindClosestEntrance();
      
      _movement.SetTarget(_targetEntrance.Position);
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

    private EntranceBase FindClosestEntrance()
    {
      EntranceBase closestEntrance = null;
      float minDistance = Mathf.Infinity;

      foreach (EntranceBase entrance in HouseEntrancesContainer.Instance.Entrances)
      {
        NavMeshPath navMeshPath = new NavMeshPath();
        if (NavMesh.CalculatePath(transform.position, entrance.Position, NavMesh.AllAreas, navMeshPath))
        {
          float distance = NavMeshExtensions.CalculatePathDistance(navMeshPath);

          if (distance < minDistance)
          {
            minDistance = distance;
            closestEntrance = entrance;
          }
        }
      }
      
      return closestEntrance;
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