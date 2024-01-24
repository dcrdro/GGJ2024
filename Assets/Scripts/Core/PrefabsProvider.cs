using UnityEngine;

namespace Core
{
  public class PrefabsProvider : MonoBehaviour
  {
    public static PrefabsProvider Instance;

    public GameObject EnemyPrefab;
    
    private void Awake() => 
      Instance = this;
  }
}