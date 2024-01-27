using Core;
using Extensions;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class MoveToSpawnPointState : ExitableStateBase, IState
  {
    [SerializeField, HideInInspector]
    private EnemyMovement _movement;

    public void Enter()
    {
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
    }
#endif
  }
}