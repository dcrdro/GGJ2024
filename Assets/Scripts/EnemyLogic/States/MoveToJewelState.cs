using Core;
using Extensions;
using JewelLogic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyLogic.States
{
  public class MoveToJewelState : StateBase, IState
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
      _currentJewel.OnPickedUp += FindTarget;
    }

    public void Exit()
    {
      _movement.ToggleMovement(false);
      _movement.OnTargetReached -= OnReachedJewel;
      _currentJewel.OnPickedUp -= FindTarget;
    }

    private void FindTarget()
    {
      _currentJewel = FindClosestJewel();
      
      _movement.ToggleMovement(true);
      _movement.SetTarget(_currentJewel.Position);
    }

    private void OnReachedJewel()
    {
      _stateMachine.Enter<JewelPickUpState, Jewel>(_currentJewel);
    }

    private Jewel FindClosestJewel()
    {
      Jewel closestJewel = null;
      float minDistance = Mathf.Infinity;

      for (int jewelIndex = 0; jewelIndex < JewelsContainer.Instance.Length; jewelIndex++)
      {
        NavMeshPath navMeshPath = new NavMeshPath();
        Jewel jewel = JewelsContainer.Instance[jewelIndex];

        if (NavMesh.CalculatePath(transform.position, jewel.Position, NavMesh.AllAreas, navMeshPath))
        {
          float distance = NavMeshExtensions.CalculatePathDistance(navMeshPath);

          if (distance < minDistance)
          {
            minDistance = distance;
            closestJewel = jewel;
          }
        }
      }

      return closestJewel;
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