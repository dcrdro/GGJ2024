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
  }
}