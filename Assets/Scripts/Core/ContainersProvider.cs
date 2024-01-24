using UnityEngine;

namespace Core
{
  public class ContainersProvider : MonoBehaviour
  {
    public static ContainersProvider Instance;

    public Transform EnemiesContainer;
    
    private void Awake() => 
      Instance = this;
  }
}