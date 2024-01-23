using Core;
using Extensions;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyLogic.States
{
  public class EscapeFromHouseState : StateBase, IState
  {
    [SerializeField, HideInInspector]
    private EnemyMovement _movement;

    public void Enter()
    {
      Transform closestSpawnPoint = FindClosestSpawnPoint();
      
      _movement.ToggleMovement(true);
      _movement.SetTarget(closestSpawnPoint.position);

      _movement.OnTargetReached += OnReachedTarget;
    }

    public void Exit()
    {
      _movement.ToggleMovement(false);
      _movement.OnTargetReached -= OnReachedTarget;
    }

    private void OnReachedTarget() => 
      Destroy(gameObject);

    private Transform FindClosestSpawnPoint()
    {
      Transform closestSpawnPoint = null;
      float minDistance = Mathf.Infinity;

      for (int spawnPointIndex = 0; spawnPointIndex < EnemySpawnPointsContainer.Instance.Length; spawnPointIndex++)
      {
        NavMeshPath navMeshPath = new NavMeshPath();
        Transform spawnPoint = EnemySpawnPointsContainer.Instance[spawnPointIndex];
    
        if (NavMesh.CalculatePath(transform.position, spawnPoint.position, NavMesh.AllAreas, navMeshPath))
        {
          float distance = NavMeshExtensions.CalculatePathDistance(navMeshPath);
    
          if (distance < minDistance)
          {
            minDistance = distance;
            closestSpawnPoint = spawnPoint;
          }
        }
      }
    
      return closestSpawnPoint;
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