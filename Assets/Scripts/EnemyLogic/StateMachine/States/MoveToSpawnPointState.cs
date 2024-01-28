using Core;
using Extensions;
using UI;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class MoveToSpawnPointState : ExitableStateBase, IState
  {
    [SerializeField, HideInInspector]
    private EnemyMovement _movement;

    [SerializeField, HideInInspector]
    private EnemySharedState _sharedState;

    public void Enter()
    {
      if(_sharedState.Jewel != null)
        JewelsCounter.Instance.DecreaseJewelsCount();
      
      Transform closestSpawnPoint = NavMeshExtensions.FindClosestSpawnPoint(transform.position);

      _movement.ToggleMovement(true);
      _movement.SetTarget(closestSpawnPoint.position);

      _movement.OnTargetReached += OnReachedTarget;
    }

    public override void Exit()
    {
      base.Exit();

      _movement.ToggleMovement(false);
      _movement.OnTargetReached -= OnReachedTarget;
    }

    private void OnReachedTarget()
    {
      EnemySpawnPointsContainer.Instance.EscapedCount++;
      Destroy(gameObject);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
      if (_movement == null)
        TryGetComponent(out _movement);

      if (_sharedState == null)
        TryGetComponent(out _sharedState);
    }
#endif
  }
}