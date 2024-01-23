using Core;
using JewelLogic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyLogic
{
  [RequireComponent(typeof(EnemyMovement))]
  public class EnemyJewelDetector : MonoBehaviour
  {
    [SerializeField, HideInInspector]
    private EnemyMovement _movement;

    private void Start()
    {
      Jewel closestJewel =  FindClosestJewel();
      _movement.SetTarget(closestJewel.Position);
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
          float distance = CalculatePathDistance(navMeshPath);

          if (distance < minDistance)
          {
            minDistance = distance;
            closestJewel = jewel;
          }
        }
      }

      return closestJewel;
    }

    private float CalculatePathDistance(NavMeshPath path)
    {
      float distance = 0;

      for (int cornerIndex = 0; cornerIndex < path.corners.Length - 1; cornerIndex++)
        distance += Vector3.Distance(path.corners[cornerIndex], path.corners[cornerIndex + 1]);

      return distance;
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