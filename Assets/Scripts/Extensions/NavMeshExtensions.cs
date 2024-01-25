using Core;
using HouseLogic.Entrances;
using JewelLogic;
using UnityEngine;
using UnityEngine.AI;

namespace Extensions
{
  public static class NavMeshExtensions
  {
    public static float CalculatePathDistance(NavMeshPath path)
    {
      float distance = 0;

      for (int cornerIndex = 0; cornerIndex < path.corners.Length - 1; cornerIndex++)
        distance += Vector3.Distance(path.corners[cornerIndex], path.corners[cornerIndex + 1]);

      return distance;
    }
    
    public static EntranceBase FindClosestEntrance(Vector3 currentPosition)
    {
      EntranceBase closestEntrance = null;
      float minDistance = Mathf.Infinity;

      foreach (EntranceBase entrance in HouseEntrancesContainer.Instance.Entrances)
      {
        NavMeshPath navMeshPath = new NavMeshPath();
        if (NavMesh.CalculatePath(currentPosition, entrance.OutsidePoint, NavMesh.AllAreas, navMeshPath))
        {
          float distance = CalculatePathDistance(navMeshPath);

          if (distance < minDistance)
          {
            minDistance = distance;
            closestEntrance = entrance;
          }
        }
      }
      
      return closestEntrance;
    }
    
    public static Transform FindClosestSpawnPoint(Vector3 currentPosition)
    {
      Transform closestSpawnPoint = null;
      float minDistance = Mathf.Infinity;

      for (int spawnPointIndex = 0; spawnPointIndex < EnemySpawnPointsContainer.Instance.Length; spawnPointIndex++)
      {
        NavMeshPath navMeshPath = new NavMeshPath();
        Transform spawnPoint = EnemySpawnPointsContainer.Instance[spawnPointIndex];
    
        if (NavMesh.CalculatePath(currentPosition, spawnPoint.position, NavMesh.AllAreas, navMeshPath))
        {
          float distance = CalculatePathDistance(navMeshPath);
    
          if (distance < minDistance)
          {
            minDistance = distance;
            closestSpawnPoint = spawnPoint;
          }
        }
      }
    
      return closestSpawnPoint;
    }
    
    public static Jewel FindClosestJewel(Vector3 currentPosition)
    {
      Jewel closestJewel = null;
      float minDistance = Mathf.Infinity;

      for (int jewelIndex = 0; jewelIndex < JewelsContainer.Instance.Length; jewelIndex++)
      {
        NavMeshPath navMeshPath = new NavMeshPath();
        Jewel jewel = JewelsContainer.Instance[jewelIndex];

        if (NavMesh.CalculatePath(currentPosition, jewel.Position, NavMesh.AllAreas, navMeshPath))
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
  }
}